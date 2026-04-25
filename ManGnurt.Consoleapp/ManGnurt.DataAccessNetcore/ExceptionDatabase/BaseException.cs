using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.ExceptionDatabase
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }

        public BaseException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
