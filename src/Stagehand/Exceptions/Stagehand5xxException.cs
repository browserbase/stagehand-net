using System.Net.Http;

namespace Stagehand.Exceptions;

public class Stagehand5xxException : StagehandApiException
{
    public Stagehand5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
