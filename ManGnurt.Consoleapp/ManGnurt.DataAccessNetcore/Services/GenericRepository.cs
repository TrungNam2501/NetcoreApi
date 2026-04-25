using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ManGnurtDbContext _dbContext;
        public GenericRepository(ManGnurtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(T t)
        {
            _dbContext.Set<T>().Remove(t);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetList(object parameters = null)
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual async Task<int> Insert(T t)
        {
            try
            {
                //check du lieu dau vao
                if (t == null)
                {
                    throw new Exception("Dữ liệu đầu vào không hợp lệ");
                }

                _dbContext.Set<T>().Add(t);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Update(T t)
        {
            try
            {
                _dbContext.Set<T>().Update(t);
                return await _dbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
