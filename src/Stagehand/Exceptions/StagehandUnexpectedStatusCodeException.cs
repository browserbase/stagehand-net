using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandUnexpectedStatusCodeException : StagehandApiException
{
    public StagehandUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
