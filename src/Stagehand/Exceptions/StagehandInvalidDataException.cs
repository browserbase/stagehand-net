using System;

namespace Stagehand.Exceptions;

public class StagehandInvalidDataException : StagehandException
{
    public StagehandInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
