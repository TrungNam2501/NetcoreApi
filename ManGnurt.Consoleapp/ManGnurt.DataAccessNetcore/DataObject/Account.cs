using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.DataObject
{
    public class Account
    {
        public int AccountID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
    }
}
