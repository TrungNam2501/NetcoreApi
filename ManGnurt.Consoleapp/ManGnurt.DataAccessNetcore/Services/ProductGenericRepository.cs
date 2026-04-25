using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class ProductGenericRepository : GenericRepository<Product>, IproductGenericRepository
    {
        public ProductGenericRepository(ManGnurtDbContext dbContext) : base(dbContext)
        {

        }
        public override async Task<int> Insert(Product t)
        {
            // 1. Kiểm tra ProductName (nvarchar 250)
            if (string.IsNullOrEmpty(t.ProductName))
                throw new ProductException("Tên sản phẩm không được để trống.");

            // 2. Kiểm tra ProductPrice (int)
            if (t.ProductPrice <= 0)
                throw new ProductException("Giá sản phẩm phải lớn hơn 0.");

            // 3. Kiểm tra CategoryID (int)
            if (t.CategoryID <= 0)
                throw new ProductException("Sản phẩm phải thuộc về một danh mục (CategoryID) hợp lệ.");

            return await base.Insert(t);
        }
    }
}
