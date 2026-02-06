using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Stagehand;
using Stagehand.Models.Sessions;

namespace Stagehand.Examples
{
    class LocalBrowserPlaywrightExample
    {
        static async Task Main(string[] args)
        {
            // Uses environment variables: MODEL_API_KEY
            // In local mode, BROWSERBASE_API_KEY and BROWSERBASE_PROJECT_ID can be any value.
            StagehandClient client = new();

            await using var playwright = await Playwright.CreateAsync();
            await using var browserServer = await playwright.Chromium.LaunchServerAsync(
                new BrowserTypeLaunchServerOptions { Headless = true }
            );
            var cdpUrl = browserServer.WsEndpoint;

            // Start a new local session using the Playwright CDP URL
            var startResponse = await client.Sessions.Start(
                new SessionStartParams
                {
                    ModelName = "gpt-4o",
                    Browser = new Browser { Type = Type.Local, CdpUrl = cdpUrl },
                }
            );
            Console.WriteLine($"Session started: {startResponse.Data.SessionID}");

            var sessionID = startResponse.Data.SessionID;

            // Connect Playwright to the same local browser
            var browser = await playwright.Chromium.ConnectOverCDPAsync(cdpUrl);
            var context =
                browser.Contexts.Count > 0 ? browser.Contexts[0] : await browser.NewContextAsync();
            var page = context.Pages.Count > 0 ? context.Pages[0] : await context.NewPageAsync();

            // Navigate to Hacker News
            await client.Sessions.Navigate(
                sessionID,
                new SessionNavigateParams { URL = "https://news.ycombinator.com" }
            );
            await page.GotoAsync("https://news.ycombinator.com");
            Console.WriteLine("Navigated to Hacker News");

            // Observe with SSE streaming to find possible actions
            var observeResponse = await CollectStreamingResult<SessionObserveResponse>(
                client.Sessions.ObserveStreaming(
                    sessionID,
                    new SessionObserveParams
                    {
                        Instruction = "find the link to view comments for the top post",
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
                    sessionID,
                    new SessionActParams
                    {
                        Input = new Input(
                            new Action
                            {
                                Description = action.Description,
                                Selector = action.Selector,
                                Method = action.Method,
                                Arguments = action.Arguments,
                            }
                        ),
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
                    sessionID,
                    new SessionExtractParams
                    {
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
                            ["required"] = JsonSerializer.SerializeToElement(
                                new[] { "commentText" }
                            ),
                        },
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
            var author =
                extractedData != null && extractedData.ContainsKey("author")
                    ? extractedData["author"].GetString()
                    : null;

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
                    sessionID,
                    new SessionExecuteAgentParams
                    {
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
                            Model = new Model(
                                new ModelConfig
                                {
                                    ModelName = "openai/gpt-4.1-mini",
                                    APIKey = Environment.GetEnvironmentVariable("MODEL_API_KEY"),
                                }
                            ),
                            Cua = false,
                        },
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
            await browser.CloseAsync();
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
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Failed to parse streaming result for {label}: {ex.Message}"
                    );
                }
            }

            return result;
        }

        static void PrintStreamEvent(string label, StreamEvent streamEvent)
        {
            var payload = streamEvent.Data.RawJSON;
            Console.WriteLine($"[{label}][{streamEvent.Type}] {payload}");
        }

        static bool TryGetFinishedResult(StreamEvent streamEvent, out JsonElement result)
        {
            result = default;

            if (streamEvent.Type != StreamEventType.System)
            {
                return false;
            }

            var system = streamEvent.Data.AsStreamEventDataStreamEventSystemDataOutput();
            if (system.Status != "finished")
            {
                return false;
            }

            if (!system.JSON.Result.TryGetValue(out result))
            {
                return false;
            }

            return true;
        }
    }
}
