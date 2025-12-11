using System.Threading.Tasks;
using Stagehand.Models.Sessions;

namespace Stagehand.Tests.Services;

public class SessionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Act_Works()
    {
        var response = await this.client.Sessions.Act(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { Input = "click the sign in button" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task End_Works()
    {
        var response = await this.client.Sessions.End(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ExecuteAgent_Works()
    {
        var response = await this.client.Sessions.ExecuteAgent(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
                AgentConfig = new()
                {
                    Cua = true,
                    Model = "openai/gpt-4o",
                    Provider = Provider.OpenAI,
                    SystemPrompt = "systemPrompt",
                },
                ExecuteOptions = new()
                {
                    Instruction = "Find and click the first product",
                    HighlightCursor = true,
                    MaxSteps = 10,
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Extract_Works()
    {
        var response = await this.client.Sessions.Extract(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Navigate_Works()
    {
        var response = await this.client.Sessions.Navigate(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { URL = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response?.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Observe_Works()
    {
        var actions = await this.client.Sessions.Observe(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in actions)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Start_Works()
    {
        var response = await this.client.Sessions.Start(
            new() { Env = Env.Local },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
