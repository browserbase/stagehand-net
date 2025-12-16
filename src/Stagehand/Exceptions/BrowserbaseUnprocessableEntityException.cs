using System.Net.Http;

namespace Stagehand.Exceptions;

public class BrowserbaseUnprocessableEntityException : Browserbase4xxException
{
    public BrowserbaseUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
