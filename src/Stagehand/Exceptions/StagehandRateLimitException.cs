using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandRateLimitException : Stagehand4xxException
{
    public StagehandRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
