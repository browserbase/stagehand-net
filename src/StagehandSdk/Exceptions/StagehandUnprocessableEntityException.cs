using System.Net.Http;

namespace StagehandSdk.Exceptions;

public class StagehandUnprocessableEntityException : Stagehand4xxException
{
    public StagehandUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
