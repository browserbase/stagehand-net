using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseUnprocessableEntityException : Browserbase4xxException
{
    public BrowserbaseUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
