using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class Browserbase5xxException : BrowserbaseApiException
{
    public Browserbase5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
