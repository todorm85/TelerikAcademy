using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range_Exceptions
{
    class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T min, T max)
            : base(String.Format("{2}\nInvalid Range. Input should be between {0} and {1}", min, max, message))
        { }

        public InvalidRangeException(T min, T max)
            : this(null, min, max)
        { }
    }
}
