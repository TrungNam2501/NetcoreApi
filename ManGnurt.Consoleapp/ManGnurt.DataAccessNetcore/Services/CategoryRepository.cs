using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
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
    }
}
