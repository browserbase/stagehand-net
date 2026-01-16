# Overview

This is a stateless SDK client for the Stagehand API provided by Browserbase.com, built using Stainless.

The Stagehand API allows users to control Browserbase cloud browsers using a natural language interface with these high-level primitives:

- `Act("do xyz on this page")` - Perform actions on the page
- `Observe("look for xyz elements on this page")` - Find interactive elements
- `Extract("find xyz information on this page")` - Extract structured data from pages

The other calls provided are `Start()` and `End()` to begin and end a browser session, and `Navigate()` which is a helper to visit a specific URL.

These primitives are intended to be combined with your browser driver library of choice, e.g. Selenium WebDriver, Playwright for .NET, PuppeteerSharp, etc.

**Links:**
- GitHub: https://github.com/browserbase/stagehand-net
- Documentation: https://docs.stagehand.dev/v3/sdk/csharp

## Usage

Refer to the README.md "# Usage" section and `./examples` directory for detailed usage examples.

For installation instructions, see the "# Installation" section of the README.

## Common Tasks

```bash
# Clone and add reference
git clone git@github.com:browserbase/stagehand-net.git
dotnet add reference stagehand-net/src/Stagehand

# Set environment variables
export BROWSERBASE_API_KEY="your-bb-api-key"
export BROWSERBASE_PROJECT_ID="your-bb-project-uuid"
export MODEL_API_KEY="sk-proj-your-llm-api-key"

# Run the example
dotnet run --project examples
```

```csharp
// Quick start
using Stagehand;

StagehandClient client = new();
var startResponse = await client.Sessions.Start(new SessionStartParams {
    ModelName = "openai/gpt-4o"
});
var sessionID = startResponse.Data.SessionID;
await client.Sessions.Navigate(sessionID, new SessionNavigateParams {
    URL = "https://example.com"
});
await client.Sessions.Act(sessionID, new SessionActParams {
    Input = new Input("click login")
});
await client.Sessions.End(sessionID, new SessionEndParams());
```
