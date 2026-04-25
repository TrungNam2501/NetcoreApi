using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.EntityFrameworkCore;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ManGnurtDbContext dbContext) : base(dbContext) { }

        public async Task<List<Category>> GetList(Category_GetlistRequest requestData)
        {
            var query = _dbSet.AsQueryable();

            if (requestData != null)
            {
                if (requestData.CategoryID.HasValue && requestData.CategoryID.Value > 0)
                {
                    query = query.Where(x => x.CategoryID == requestData.CategoryID.Value);
                }

                if (!string.IsNullOrEmpty(requestData.CategoryName))
                {
                    query = query.Where(x => x.CategoryName != null
                        && x.CategoryName.Contains(requestData.CategoryName));
                }
            }

            return await query.ToListAsync();
        }

        public override async Task<Category> Insert(Category entity)
        {
            if (string.IsNullOrEmpty(entity.CategoryName))
                throw new CategoryException("Category name is required.");

            var isDuplicate = await _dbSet.AnyAsync(c => c.CategoryName == entity.CategoryName);
            if (isDuplicate)
                throw new CategoryException("Category name already exists.");

            return await base.Insert(entity);
        }

        public override async Task<Category> Update(Category entity)
        {
            if (entity.CategoryID <= 0)
                throw new CategoryException("Category ID is not valid.");

            var existing = await _dbSet.FindAsync(entity.CategoryID);
            if (existing == null)
                throw new CategoryException("Category not found.");

            if (string.IsNullOrEmpty(entity.CategoryName))
                throw new CategoryException("Category name is required.");

            var isDuplicate = await _dbSet.AnyAsync(c => c.CategoryName == entity.CategoryName && c.CategoryID != entity.CategoryID);
            if (isDuplicate)
                throw new CategoryException("Category name already exists.");

            existing.CategoryName = entity.CategoryName;

            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public override async Task Delete(int id)
        {
            if (id <= 0)
                throw new CategoryException("Category ID is not valid.");

            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new CategoryException("Category not found.");

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
