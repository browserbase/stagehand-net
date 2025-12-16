using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseForbiddenException : Browserbase4xxException
{
    public BrowserbaseForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
