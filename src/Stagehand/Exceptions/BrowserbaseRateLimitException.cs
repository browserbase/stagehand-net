using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseRateLimitException : Browserbase4xxException
{
    public BrowserbaseRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
