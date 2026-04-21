using ManGnurt.DataAccess.Class;
using ManGnurt.DataAccess.RequestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Interface
{
    public interface IProductManagement
    {
        List<Product_GetListResponseData> Product_Getlist(Product_GetListRequestData requestData);
        int Product_Insert(Product_InsertRequestData requestData);
      
    }
}
