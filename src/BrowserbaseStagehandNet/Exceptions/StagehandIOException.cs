using System;
using System.Net.Http;

namespace BrowserbaseStagehandNet.Exceptions;

public class StagehandIOException : StagehandException
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

    public StagehandIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
