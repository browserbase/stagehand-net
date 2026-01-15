using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandBadRequestException : Stagehand4xxException
{
    public StagehandBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
