using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> Delete(T t);
        Task<List<T>> GetList(object parameters = null);
        Task<int> Insert(T t);
        Task<int> Update(T t);
      


    }
}
