using System.Threading.Tasks;

namespace Stagehand.Tests.Services;

public class SessionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Start_Works()
    {
        await this.client.Sessions.Start(new(), TestContext.Current.CancellationToken);
    }
}
