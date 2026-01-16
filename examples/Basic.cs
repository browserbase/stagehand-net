using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Stagehand;
using Stagehand.Models.Sessions;

namespace Stagehand.Examples
{
    class Basic
    {
        static async Task Main(string[] args)
        {
            // Uses environment variables: BROWSERBASE_API_KEY, BROWSERBASE_PROJECT_ID, MODEL_API_KEY
            StagehandClient client = new();

            // Start a new session
            var startResponse = await client.Sessions.Start(new SessionStartParams
            {
                ModelName = "gpt-4o"
            });
            Console.WriteLine($"Session started: {startResponse.Data.SessionID}");

            var sessionID = startResponse.Data.SessionID;

            // Navigate to Hacker News
            await client.Sessions.Navigate(sessionID, new SessionNavigateParams
            {
                URL = "https://news.ycombinator.com"
            });
            Console.WriteLine("Navigated to Hacker News");

            // Observe to find possible actions
            var observeResponse = await client.Sessions.Observe(sessionID, new SessionObserveParams
            {
                Instruction = "find the link to view comments for the top post"
            });

            var actions = observeResponse.Data.Result;
            Console.WriteLine($"Found {actions.Count} possible actions");

            if (actions.Count == 0)
            {
                Console.WriteLine("No actions found");
                return;
            }

            // Use the first action
            var action = actions[0];
            Console.WriteLine($"Acting on: {action.Description}");

            // Pass the action to Act
            var actResponse = await client.Sessions.Act(sessionID, new SessionActParams
            {
                Input = new Stagehand.Models.Sessions.Input(new Stagehand.Models.Sessions.Action
                {
                    Description = action.Description,
                    Selector = action.Selector,
                    Method = action.Method,
                    Arguments = action.Arguments
                })
            });
            Console.WriteLine($"Act completed: {actResponse.Data.Result.Message}");

            // Extract data from the page
            // We're now on the comments page, so extract the top comment text
            var extractResponse = await client.Sessions.Extract(sessionID, new SessionExtractParams
            {
                Instruction = "extract the text of the top comment on this page",
                Schema = new Dictionary<string, JsonElement>
                {
                    ["type"] = JsonSerializer.SerializeToElement("object"),
                    ["properties"] = JsonSerializer.SerializeToElement(new Dictionary<string, object>
                    {
                        ["commentText"] = new Dictionary<string, string>
                        {
                            ["type"] = "string",
                            ["description"] = "The text content of the top comment"
                        },
                        ["author"] = new Dictionary<string, string>
                        {
                            ["type"] = "string",
                            ["description"] = "The username of the comment author"
                        }
                    }),
                    ["required"] = JsonSerializer.SerializeToElement(new[] { "commentText" })
                }
            });
            Console.WriteLine($"Extracted data: {extractResponse.Data.Result}");

            // Get the author from the extracted data
            var extractedData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                extractResponse.Data.Result.ToString()
            );
            var author = extractedData["author"].GetString();
            Console.WriteLine($"Looking up profile for author: {author}");

            // Use the Agent to find the author's profile
            // Execute runs an autonomous agent that can navigate and interact with pages
            var executeResponse = await client.Sessions.Execute(sessionID, new SessionExecuteAgentParams
            {
                ExecuteOptions = new ExecuteOptions
                {
                    Instruction = $"Find any personal website, GitHub, LinkedIn, or other best profile URL for the Hacker News user '{author}'. " +
                                  $"Click on their username to go to their profile page and look for any links they have shared. " +
                                  $"Use Google Search with their username or other details from their profile if you dont find any direct links.",
                    MaxSteps = 15
                },
                AgentConfig = new AgentConfig
                {
                    Model = new Model(new ModelConfig
                    {
                        ModelName = "openai/gpt-4.1-mini",
                        APIKey = Environment.GetEnvironmentVariable("MODEL_API_KEY")
                    }),
                    Cua = false
                }
            });
            Console.WriteLine($"Agent completed: {executeResponse.Data.Result.Message}");
            Console.WriteLine($"Agent success: {executeResponse.Data.Result.Success}");
            Console.WriteLine($"Agent actions taken: {executeResponse.Data.Result.Actions.Count}");

            // End the session to clean up resources
            await client.Sessions.End(sessionID, new SessionEndParams());
            Console.WriteLine("Session ended");
        }
    }
}
