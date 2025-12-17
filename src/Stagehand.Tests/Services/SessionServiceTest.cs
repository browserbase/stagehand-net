using System.Text.Json;
using System.Threading.Tasks;

namespace Stagehand.Tests.Services;

public class SessionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Act_Works()
    {
        await this.client.Sessions.Act(
            JsonSerializer.Deserialize<JsonElement>("{}"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task End_Works()
    {
        await this.client.Sessions.End(
            JsonSerializer.Deserialize<JsonElement>("{}"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ExecuteAgent_Works()
    {
        await this.client.Sessions.ExecuteAgent(
            JsonSerializer.Deserialize<JsonElement>("{}"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Extract_Works()
    {
        await this.client.Sessions.Extract(
            JsonSerializer.Deserialize<JsonElement>("{}"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Navigate_Works()
    {
        await this.client.Sessions.Navigate(
            JsonSerializer.Deserialize<JsonElement>("{}"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Observe_Works()
    {
        await this.client.Sessions.Observe(
            JsonSerializer.Deserialize<JsonElement>("{}"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Start_Works()
    {
        await this.client.Sessions.Start(new(), TestContext.Current.CancellationToken);
    }
}
