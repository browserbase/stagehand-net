using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseNotFoundException : Browserbase4xxException
{
    public BrowserbaseNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
