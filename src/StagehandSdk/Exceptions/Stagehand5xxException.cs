using System.Net.Http;

namespace StagehandSdk.Exceptions;

public class Stagehand5xxException : StagehandApiException
{
    public Stagehand5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
