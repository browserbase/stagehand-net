using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseUnauthorizedException : Browserbase4xxException
{
    public BrowserbaseUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
