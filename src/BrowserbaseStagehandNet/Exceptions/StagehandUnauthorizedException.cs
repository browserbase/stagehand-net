using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class StagehandUnauthorizedException : Stagehand4xxException
{
    public StagehandUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
