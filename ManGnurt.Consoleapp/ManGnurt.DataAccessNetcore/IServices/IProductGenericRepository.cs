using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.RequestData;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IProductGenericRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetList(Product_GetListRequestData requestData);
    }
}
