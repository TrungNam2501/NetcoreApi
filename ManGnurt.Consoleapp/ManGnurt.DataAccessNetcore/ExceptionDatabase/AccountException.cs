using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.ExceptionDatabase
{
    public class AccountException : BaseException
    {
        public AccountException(string message) : base($"[Account Error]: {message}", 400)
        {
        }
    }
}