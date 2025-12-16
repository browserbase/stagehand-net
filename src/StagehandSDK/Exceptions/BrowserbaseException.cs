using System;
using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseException : Exception
{
    public BrowserbaseException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected BrowserbaseException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
