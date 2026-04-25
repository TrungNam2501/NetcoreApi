using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.ExceptionDatabase
{
    public class CategoryException : BaseException
    {
        public CategoryException(string message) : base($"[Category Error]: {message}", 400)
        {
        }
    }
}
