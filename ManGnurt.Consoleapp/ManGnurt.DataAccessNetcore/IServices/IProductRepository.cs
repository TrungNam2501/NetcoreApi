using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.RequestData;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> Product_Getlist(Product_GetListRequestData requestData);
        Task<ReturnData> Product_Insert(Product_InsertRequestData requestData);
        Task<List<Product>> Product_Getlist_EfCore(Product_GetListRequestData requestData);
        Task<ReturnData> Product_Update_EfCore(Product_UpdateRequestData requestData);
        Task<ReturnData> Product_Delete_EfCore(Product_DeleteRequestData requestData);
    }
}
