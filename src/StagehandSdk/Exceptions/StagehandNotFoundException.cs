using System.Net.Http;

namespace StagehandSdk.Exceptions;

public class StagehandNotFoundException : Stagehand4xxException
{
    public StagehandNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
