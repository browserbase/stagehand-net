using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseBadRequestException : Browserbase4xxException
{
    public BrowserbaseBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
