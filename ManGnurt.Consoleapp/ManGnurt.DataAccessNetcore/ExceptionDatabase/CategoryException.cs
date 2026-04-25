using System;

namespace ManGnurt.DataAccessNetcore.ExceptionDatabase
{
    public class CategoryException : Exception
    {
        public CategoryException() { }

        public CategoryException(string message) : base(message) { }

        public CategoryException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
