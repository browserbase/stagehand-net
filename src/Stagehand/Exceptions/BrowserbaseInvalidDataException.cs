using System;

namespace Stagehand.Exceptions;

public class BrowserbaseInvalidDataException : BrowserbaseException
{
    public BrowserbaseInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
