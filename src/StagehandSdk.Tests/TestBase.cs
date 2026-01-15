using System;
using StagehandSdk;

namespace StagehandSdk.Tests;

public class TestBase
{
    protected IStagehandClient client;

    public TestBase()
    {
        client = new StagehandClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            BrowserbaseApiKey = "My Browserbase API Key",
            BrowserbaseProjectID = "My Browserbase Project ID",
            ModelApiKey = "My Model API Key",
        };
    }
}
