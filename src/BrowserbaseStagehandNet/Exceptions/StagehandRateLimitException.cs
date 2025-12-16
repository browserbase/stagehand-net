using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class StagehandRateLimitException : Stagehand4xxException
{
    public StagehandRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
