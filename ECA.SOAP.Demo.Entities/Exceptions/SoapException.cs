using System;
using System.Runtime.Serialization;

namespace ECA.SOAP.Demo.Entities.Exceptions;

[Serializable]
public class SoapException : Exception
{
    public SoapException()
    { }

    public SoapException(string message) : base(message)
    {
    }

    public SoapException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected SoapException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}