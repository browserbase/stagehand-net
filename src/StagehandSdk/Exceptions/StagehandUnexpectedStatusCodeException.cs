using System.Net.Http;

namespace StagehandSdk.Exceptions;

public class StagehandUnexpectedStatusCodeException : StagehandApiException
{
    public StagehandUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
