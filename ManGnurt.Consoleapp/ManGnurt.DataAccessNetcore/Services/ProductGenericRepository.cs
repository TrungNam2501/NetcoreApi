using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.EntityFrameworkCore;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class ProductGenericRepository : GenericRepository<Product>, IProductGenericRepository
    {
        public ProductGenericRepository(ManGnurtDbContext dbContext) : base(dbContext) { }

        public async Task<List<Product>> GetList(Product_GetListRequestData requestData)
        {
            var query = _dbSet.AsQueryable();

            if (requestData != null)
            {
                if (requestData.ProductID.HasValue && requestData.ProductID.Value > 0)
                {
                    query = query.Where(x => x.ProductID == requestData.ProductID.Value);
                }
                else if (requestData.ListProductID != null && requestData.ListProductID.Any(id => id > 0))
                {
                    var validIds = requestData.ListProductID.Where(id => id > 0).ToList();
                    query = query.Where(x => validIds.Contains(x.ProductID));
                }
            }

            return await query.ToListAsync();
        }

        public override async Task<Product> Insert(Product entity)
        {
            if (string.IsNullOrEmpty(entity.ProductName))
                throw new ProductException("Product name is required.");

            if (entity.ProductPrice == null || entity.ProductPrice <= 0)
                throw new ProductException("Product price must be greater than 0.");

            var isDuplicate = await _dbSet.AnyAsync(p => p.ProductName == entity.ProductName);
            if (isDuplicate)
                throw new ProductException("Product name already exists.");

            return await base.Insert(entity);
        }
    }
}
