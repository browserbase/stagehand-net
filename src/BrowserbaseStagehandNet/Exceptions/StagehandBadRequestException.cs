using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class StagehandBadRequestException : Stagehand4xxException
{
    public StagehandBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
