using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.IServices;
using Microsoft.EntityFrameworkCore;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ManGnurtDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ManGnurtDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
