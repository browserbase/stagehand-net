using System.Net.Http;

namespace StagehandSdk.Exceptions;

public class StagehandBadRequestException : Stagehand4xxException
{
    public StagehandBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
