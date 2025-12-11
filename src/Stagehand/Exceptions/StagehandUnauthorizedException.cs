using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandUnauthorizedException : Stagehand4xxException
{
    public StagehandUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
