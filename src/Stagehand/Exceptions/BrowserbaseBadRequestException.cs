using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseBadRequestException : Browserbase4xxException
{
    public BrowserbaseBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
