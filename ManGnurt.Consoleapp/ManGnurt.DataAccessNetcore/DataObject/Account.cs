using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManGnurt.DataAccessNetcore.DataObject
{
    [Table("Account")] // Khai báo tên bảng trong Database
    public class Account
    {
        [Key] // Đánh dấu là Khóa chính
        public int AccountID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
    }
}
