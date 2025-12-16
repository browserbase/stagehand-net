using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class StagehandUnexpectedStatusCodeException : StagehandApiException
{
    public StagehandUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
