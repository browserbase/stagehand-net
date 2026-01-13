> [!NOTE]
> The Stagehand C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/browserbase/stagehand-net/issues/new).

<div id="toc" align="center" style="margin-bottom: 0;">
  <ul style="list-style: none; margin: 0; padding: 0;">
    <a href="https://stagehand.dev">
      <picture>
        <source media="(prefers-color-scheme: dark)" srcset="media/dark_logo.png" />
        <img alt="Stagehand" src="media/light_logo.png" width="200" style="margin-right: 30px;" />
      </picture>
    </a>
  </ul>
</div>
<p align="center">
  <strong>The AI Browser Automation Framework</strong><br>
  <a href="https://docs.stagehand.dev/v3/sdk/csharp">Read the Docs</a>
</p>

<p align="center">
  <a href="https://github.com/browserbase/stagehand/tree/main?tab=MIT-1-ov-file#MIT-1-ov-file">
    <picture>
      <source media="(prefers-color-scheme: dark)" srcset="media/dark_license.svg" />
      <img alt="MIT License" src="media/light_license.svg" />
    </picture>
  </a>
  <a href="https://stagehand.dev/discord">
    <picture>
      <source media="(prefers-color-scheme: dark)" srcset="media/dark_discord.svg" />
      <img alt="Discord Community" src="media/light_discord.svg" />
    </picture>
  </a>
</p>

<p align="center">
	<a href="https://trendshift.io/repositories/12122" target="_blank"><img src="https://trendshift.io/api/badge/repositories/12122" alt="browserbase%2Fstagehand | Trendshift" style="width: 250px; height: 55px;" width="250" height="55"/></a>
</p>

<p align="center">
If you're looking for other languages, you can find them
<a href="https://docs.stagehand.dev/v3/first-steps/introduction"> here</a>
</p>

<div align="center" style="display: flex; align-items: center; justify-content: center; gap: 4px; margin-bottom: 0;">
  <b>Vibe code</b>
  <span style="font-size: 1.05em;"> Stagehand with </span>
  <a href="https://director.ai" style="display: flex; align-items: center;">
    <span>Director</span>
  </a>
  <span> </span>
  <picture>
    <img alt="Director" src="media/director_icon.svg" width="25" />
  </picture>
</div>

## What is Stagehand?

Stagehand is a browser automation framework used to control web browsers with natural language and code. By combining the power of AI with the precision of code, Stagehand makes web automation flexible, maintainable, and actually reliable.

## Why Stagehand?

Most existing browser automation tools either require you to write low-level code in a framework like Selenium, Playwright, or Puppeteer, or use high-level agents that can be unpredictable in production. By letting developers choose what to write in code vs. natural language (and bridging the gap between the two) Stagehand is the natural choice for browser automations in production.

1. **Choose when to write code vs. natural language**: use AI when you want to navigate unfamiliar pages, and use code when you know exactly what you want to do.

2. **Go from AI-driven to repeatable workflows**: Stagehand lets you preview AI actions before running them, and also helps you easily cache repeatable actions to save time and tokens.

3. **Write once, run forever**: Stagehand's auto-caching combined with self-healing remembers previous actions, runs without LLM inference, and knows when to involve AI whenever the website changes and your automation breaks.

## Installation

```bash
git clone git@github.com:browserbase/stagehand-net.git
dotnet add reference stagehand-net/src/Stagehand
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

```csharp
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
```

## Client configuration

Configure the client using environment variables:

```csharp
using Stagehand;

// Configured using the BROWSERBASE_API_KEY, BROWSERBASE_PROJECT_ID, MODEL_API_KEY and STAGEHAND_BASE_URL environment variables
StagehandClient client = new();
```

Or manually:

```csharp
using Stagehand;

StagehandClient client = new()
{
    BrowserbaseAPIKey = "My Browserbase API Key",
    BrowserbaseProjectID = "My Browserbase Project ID",
    ModelAPIKey = "My Model API Key",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property               | Environment variable     | Required | Default value                                |
| ---------------------- | ------------------------ | -------- | -------------------------------------------- |
| `BrowserbaseAPIKey`    | `BROWSERBASE_API_KEY`    | true     | -                                            |
| `BrowserbaseProjectID` | `BROWSERBASE_PROJECT_ID` | true     | -                                            |
| `ModelAPIKey`          | `MODEL_API_KEY`          | true     | -                                            |
| `BaseUrl`              | `STAGEHAND_BASE_URL`     | true     | `"https://api.stagehand.browserbase.com/v1"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Sessions.Start(parameters);

Console.WriteLine(response);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Stagehand API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Sessions.Act` should be called with an instance of `SessionActParams`, and it will return an instance of `Task<SessionActResponse>`.

## Error handling

The SDK throws custom unchecked exception types:

- `StagehandApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                |
| ------ | ---------------------------------------- |
| 400    | `StagehandBadRequestException`           |
| 401    | `StagehandUnauthorizedException`         |
| 403    | `StagehandForbiddenException`            |
| 404    | `StagehandNotFoundException`             |
| 422    | `StagehandUnprocessableEntityException`  |
| 429    | `StagehandRateLimitException`            |
| 5xx    | `Stagehand5xxException`                  |
| others | `StagehandUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Stagehand4xxException`.

false

- `StagehandIOException`: I/O networking errors.

- `StagehandInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `StagehandException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Stagehand;

StagehandClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Sessions.Start(parameters);

Console.WriteLine(response);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Stagehand;

StagehandClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Sessions.Start(parameters);

Console.WriteLine(response);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `StagehandInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var response = client.Sessions.Act(parameters);
response.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Stagehand;

StagehandClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Sessions.Act(parameters);

Console.WriteLine(response);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/browserbase/stagehand-net/issues) with questions, bugs, or suggestions.
