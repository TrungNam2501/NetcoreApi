using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.RequestData;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<List<Account>> GetList(Account_GetListRequestData requestData);
    }
}
