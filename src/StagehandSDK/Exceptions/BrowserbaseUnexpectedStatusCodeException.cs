using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseUnexpectedStatusCodeException : BrowserbaseApiException
{
    public BrowserbaseUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
