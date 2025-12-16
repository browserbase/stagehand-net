using System.Net.Http;

namespace Stagehand.Exceptions;

public class Browserbase5xxException : BrowserbaseApiException
{
    public Browserbase5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
