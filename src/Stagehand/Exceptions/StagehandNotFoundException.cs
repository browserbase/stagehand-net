using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandNotFoundException : Stagehand4xxException
{
    public StagehandNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
