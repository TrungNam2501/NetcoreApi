using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.RequestData;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetList(Category_GetlistRequest requestData);
    }
}
