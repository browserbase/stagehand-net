using System;
using Stagehand;

namespace Stagehand.Tests;

public class TestBase
{
    protected IStagehandClient client;

    public TestBase()
    {
        client = new StagehandClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            BrowserbaseAPIKey = "My Browserbase API Key",
            BrowserbaseProjectID = "My Browserbase Project ID",
            ModelAPIKey = "My Model API Key",
        };
    }
}
