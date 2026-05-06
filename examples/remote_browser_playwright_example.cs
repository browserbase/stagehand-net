using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Stagehand;
using Stagehand.Models.Sessions;
using SessionType = Stagehand.Models.Sessions.Type;
using StagehandAction = Stagehand.Models.Sessions.Action;

namespace Stagehand.Examples
{
    internal static class RemoteBrowserPlaywrightExample
    {
        private static readonly string[] RequiredExtractFields = ["commentText"];

        public static async Task RunAsync()
        {
            Env.Load();
            // Uses environment variables: BROWSERBASE_API_KEY and MODEL_API_KEY
            StagehandClient client = new();

            // Start a new remote Browserbase session (Playwright-backed)
            var startResponse = await client.Sessions.Start(
                new SessionStartParams
                {
                    ModelName = "anthropic/claude-sonnet-4-6",
                    Browser = new Browser { Type = SessionType.Browserbase },
                }
            );
            Console.WriteLine($"Session started: {startResponse.Data.SessionID}");

            var sessionID = startResponse.Data.SessionID;

            // Navigate to Hacker News
            await client.Sessions.Navigate(
                sessionID,
                new SessionNavigateParams { UrlValue = "https://news.ycombinator.com" }
            );
            Console.WriteLine("Navigated to Hacker News");

            // Observe with SSE streaming to find possible actions
            var observeResponse = await CollectStreamingResult<SessionObserveResponse>(
                client.Sessions.ObserveStreaming(
                    new SessionObserveParams
                    {
                        ID = sessionID,
                        Instruction = "find the link to view comments for the top post",
                        XStreamResponse = SessionObserveParamsXStreamResponse.True,
                    }
                ),
                "observe"
            );

            if (observeResponse == null || observeResponse.Data.Result.Count == 0)
            {
                Console.WriteLine("No actions found");
                await client.Sessions.End(sessionID, new SessionEndParams());
                return;
            }

            // Use the first action
            var action = observeResponse.Data.Result[0];
            Console.WriteLine($"Acting on: {action.Description}");

            // Pass the action to Act (streaming)
            var actResponse = await CollectStreamingResult<SessionActResponse>(
                client.Sessions.ActStreaming(
                    new SessionActParams
                    {
                        ID = sessionID,
                        Input = new Input(
                            new StagehandAction
                            {
                                Description = action.Description,
                                Selector = action.Selector,
                                Method = action.Method,
                                Arguments = action.Arguments,
                            }
                        ),
                        XStreamResponse = XStreamResponse.True,
                    }
                ),
                "act"
            );

            if (actResponse != null)
            {
                Console.WriteLine($"Act completed: {actResponse.Data.Result.Message}");
            }

            // Extract data from the page (streaming)
            var extractResponse = await CollectStreamingResult<SessionExtractResponse>(
                client.Sessions.ExtractStreaming(
                    new SessionExtractParams
                    {
                        ID = sessionID,
                        Instruction = "extract the text of the top comment on this page",
                        Schema = new Dictionary<string, JsonElement>
                        {
                            ["type"] = JsonSerializer.SerializeToElement("object"),
                            ["properties"] = JsonSerializer.SerializeToElement(
                                new Dictionary<string, object>
                                {
                                    ["commentText"] = new Dictionary<string, string>
                                    {
                                        ["type"] = "string",
                                        ["description"] = "The text content of the top comment",
                                    },
                                    ["author"] = new Dictionary<string, string>
                                    {
                                        ["type"] = "string",
                                        ["description"] = "The username of the comment author",
                                    },
                                }
                            ),
                            ["required"] = JsonSerializer.SerializeToElement(RequiredExtractFields),
                        },
                        XStreamResponse = SessionExtractParamsXStreamResponse.True,
                    }
                ),
                "extract"
            );

            if (extractResponse == null)
            {
                Console.WriteLine("No extract response received");
                await client.Sessions.End(sessionID, new SessionEndParams());
                return;
            }

            Console.WriteLine($"Extracted data: {extractResponse.Data.Result}");

            var extractedData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                extractResponse.Data.Result.ToString()
            );
            string? author = null;
            if (extractedData != null && extractedData.TryGetValue("author", out var authorElement))
            {
                author = authorElement.GetString();
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("No author found in extracted data");
                await client.Sessions.End(sessionID, new SessionEndParams());
                return;
            }

            Console.WriteLine($"Looking up profile for author: {author}");

            // Use the Agent to find the author's profile (streaming)
            var executeResponse = await CollectStreamingResult<SessionExecuteResponse>(
                client.Sessions.ExecuteStreaming(
                    new SessionExecuteParams
                    {
                        ID = sessionID,
                        ExecuteOptions = new ExecuteOptions
                        {
                            Instruction =
                                $"Find any personal website, GitHub, LinkedIn, or other best profile URL for the Hacker News user '{author}'. "
                                + "Click on their username to go to their profile page and look for any links they have shared. "
                                + "Use Google Search with their username or other details from their profile if you dont find any direct links.",
                            MaxSteps = 15,
                        },
                        AgentConfig = new AgentConfig
                        {
                            Model = new AgentConfigModel(
                                new ModelConfig
                                {
                                    ModelName = "anthropic/claude-opus-4-6",
                                    ApiKey = Environment.GetEnvironmentVariable("MODEL_API_KEY"),
                                }
                            ),
                            Cua = false,
                        },
                        XStreamResponse = SessionExecuteParamsXStreamResponse.True,
                    }
                ),
                "agent"
            );

            if (executeResponse != null)
            {
                Console.WriteLine($"Agent completed: {executeResponse.Data.Result.Message}");
                Console.WriteLine($"Agent success: {executeResponse.Data.Result.Success}");
                Console.WriteLine(
                    $"Agent actions taken: {executeResponse.Data.Result.Actions.Count}"
                );
            }

            // End the session to clean up resources
            await client.Sessions.End(sessionID, new SessionEndParams());
            Console.WriteLine("Session ended");
        }

        static async Task<T?> CollectStreamingResult<T>(
            IAsyncEnumerable<StreamEvent> stream,
            string label
        )
        {
            T? result = default;

            await foreach (var streamEvent in stream)
            {
                PrintStreamEvent(label, streamEvent);

                if (!TryGetFinishedResult(streamEvent, out var resultElement))
                {
                    continue;
                }

                try
                {
                    result = JsonSerializer.Deserialize<T>(resultElement.GetRawText());
                }
                catch (JsonException)
                {
                    Console.WriteLine($"[{label}] Warning: unable to parse finished result.");
                }
            }

            return result;
        }

        static bool TryGetFinishedResult(StreamEvent streamEvent, out JsonElement resultElement)
        {
            resultElement = default;

            if (
                streamEvent.Data.TryPickStreamEventSystemDataOutput(out var systemData)
                && systemData.Result is { } result
                && systemData.Status.Value() == Status.Finished
            )
            {
                resultElement = result;
                return true;
            }

            return false;
        }

        static void PrintStreamEvent(string label, StreamEvent streamEvent)
        {
            if (streamEvent.Data.TryPickStreamEventLogDataOutput(out var logData))
            {
                Console.WriteLine($"[{label}] log: {logData.Message}");
                return;
            }

            if (streamEvent.Data.TryPickStreamEventSystemDataOutput(out var systemData))
            {
                var status = systemData.Status.Value();
                var error = string.IsNullOrWhiteSpace(systemData.Error)
                    ? string.Empty
                    : $" error={systemData.Error}";
                Console.WriteLine($"[{label}] system: {status}{error}");
                return;
            }

            Console.WriteLine($"[{label}] event: {streamEvent.Data.Json}");
        }
    }
}
