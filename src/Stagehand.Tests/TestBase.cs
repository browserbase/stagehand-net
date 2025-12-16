using System;
using Stagehand;

namespace Stagehand.Tests;

public class TestBase
{
    protected IBrowserbaseClient client;

    public TestBase()
    {
        client = new BrowserbaseClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            APIKey = "My API Key",
        };
    }
}
