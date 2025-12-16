using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseForbiddenException : Browserbase4xxException
{
    public BrowserbaseForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
