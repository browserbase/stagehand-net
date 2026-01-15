using System.Net.Http;

namespace StagehandSdk.Exceptions;

public class Stagehand4xxException : StagehandApiException
{
    public Stagehand4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
