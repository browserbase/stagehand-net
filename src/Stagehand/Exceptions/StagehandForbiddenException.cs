using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandForbiddenException : Stagehand4xxException
{
    public StagehandForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
