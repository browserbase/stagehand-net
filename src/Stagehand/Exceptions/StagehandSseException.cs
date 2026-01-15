using System;

namespace Stagehand.Exceptions;

public class StagehandSseException : StagehandException
{
    public StagehandSseException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
