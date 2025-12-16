using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class Stagehand5xxException : StagehandApiException
{
    public Stagehand5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
