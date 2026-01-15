using System;
using System.Net.Http;

namespace Stagehand.Exceptions;

public class StagehandException : Exception
{
    public StagehandException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected StagehandException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
