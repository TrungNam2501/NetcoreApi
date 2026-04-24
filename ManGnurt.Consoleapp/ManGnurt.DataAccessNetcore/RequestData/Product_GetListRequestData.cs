using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccessNetcore.RequestData
{
    public class Product_GetListRequestData
    {
        public int? ProductID { get; set; }  // Lấy 1 ID cụ thể
        public List<int>? ListProductID { get; set; } // Lấy theo danh sách ID
    }
    public class Product_InsertRequestData
    {
      
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int?   ProductPrice{get;set;}
        public int CategoryID { get; set; }
     

    }
    // Dùng kế thừa từ Insert để thêm ProductID cho việc Update
    public class Product_UpdateRequestData : Product_InsertRequestData
    {
        public int ProductID { get; set; } // Bắt buộc phải có ID để Update
    }

    public class Product_DeleteRequestData
    {
        public int ProductID { get; set; }
        public string? UserDelete { get; set; } // Ví dụ thêm người thực hiện xóa
    }
}
