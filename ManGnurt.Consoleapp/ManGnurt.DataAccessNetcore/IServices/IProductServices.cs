using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.RequestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IProductServices
    {
        
        Task<List<ProductDTO>> Product_Getlist(Product_GetListRequestData requestData);
        Task<ReturnData> Product_Insert(Product_InsertRequestData requestData);
        Task<List<Product>> Product_Getlist_EfCore(Product_GetListRequestData requestData);


    }
}
