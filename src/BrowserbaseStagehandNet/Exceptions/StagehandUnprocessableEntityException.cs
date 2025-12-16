using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class StagehandUnprocessableEntityException : Stagehand4xxException
{
    public StagehandUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
