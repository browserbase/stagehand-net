using System;
using System.Net.Http;

namespace StagehandSDK.Exceptions;

public class BrowserbaseIOException : BrowserbaseException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public BrowserbaseIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
