using System;
using System.Runtime.Serialization;

namespace IO
{
    [Serializable]
    public class ArchivoIncorrectoException : Exception
    {
        public ArchivoIncorrectoException()
        {
        }

        public ArchivoIncorrectoException(string message) : base(message)
        {
        }

        public ArchivoIncorrectoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArchivoIncorrectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}