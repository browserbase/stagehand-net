using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseNotFoundException : Browserbase4xxException
{
    public BrowserbaseNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
