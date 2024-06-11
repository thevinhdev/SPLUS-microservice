using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Common.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException()
        { }

        public GenericException(string message = "One or more validation failures have occurred")
            : base(message)
        { }

        public GenericException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
