using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseUnauthorizedException : Browserbase4xxException
{
    public BrowserbaseUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
