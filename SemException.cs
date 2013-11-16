using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MathExpr
{
    public class SemException : ApplicationException
    {
        public SemException()
      : base() {
    }

    public SemException(string message)
      : base(message) {
    }

    public SemException(string message, Exception innerException)
      : base(message, innerException) {
    }

    public SemException(SerializationInfo info, StreamingContext context)
      : base(info, context) {
    }

    }
}
