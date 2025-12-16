using System.Net.Http;

namespace Stagehand.Exceptions;

public class Browserbase4xxException : BrowserbaseApiException
{
    public Browserbase4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
