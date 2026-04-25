using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
