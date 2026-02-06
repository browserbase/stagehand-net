using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandUnprocessableEntityException : Stagehand4xxException
{
    public StagehandUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
