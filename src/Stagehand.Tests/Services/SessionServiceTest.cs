using System.Threading.Tasks;

namespace Stagehand.Tests.Services;

public class SessionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Act_Works()
    {
        var response = await this.client.Sessions.Act(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new() { Input = "Click the login button" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ActStreaming_Works()
    {
        var stream = this.client.Sessions.ActStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new() { Input = "Click the login button" },
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task End_Works()
    {
        var response = await this.client.Sessions.End(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Execute_Works()
    {
        var response = await this.client.Sessions.Execute(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new()
            {
                AgentConfig = new()
                {
                    Cua = true,
                    Model = "openai/gpt-5-nano",
                    SystemPrompt = "systemPrompt",
                },
                ExecuteOptions = new()
                {
                    Instruction =
                        "Log in with username 'demo' and password 'test123', then navigate to settings",
                    HighlightCursor = true,
                    MaxSteps = 20,
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ExecuteStreaming_Works()
    {
        var stream = this.client.Sessions.ExecuteStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new()
            {
                AgentConfig = new()
                {
                    Cua = true,
                    Model = "openai/gpt-5-nano",
                    SystemPrompt = "systemPrompt",
                },
                ExecuteOptions = new()
                {
                    Instruction =
                        "Log in with username 'demo' and password 'test123', then navigate to settings",
                    HighlightCursor = true,
                    MaxSteps = 20,
                },
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Extract_Works()
    {
        var response = await this.client.Sessions.Extract(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ExtractStreaming_Works()
    {
        var stream = this.client.Sessions.ExtractStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Navigate_Works()
    {
        var response = await this.client.Sessions.Navigate(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new() { URL = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Observe_Works()
    {
        var response = await this.client.Sessions.Observe(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ObserveStreaming_Works()
    {
        var stream = this.client.Sessions.ObserveStreaming(
            "c4dbf3a9-9a58-4b22-8a1c-9f20f9f9e123",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var response in stream)
        {
            response.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Start_Works()
    {
        var response = await this.client.Sessions.Start(
            new() { ModelName = "gpt-4o" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
