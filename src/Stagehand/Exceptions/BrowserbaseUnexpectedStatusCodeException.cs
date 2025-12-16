using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseUnexpectedStatusCodeException : BrowserbaseApiException
{
    public BrowserbaseUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
