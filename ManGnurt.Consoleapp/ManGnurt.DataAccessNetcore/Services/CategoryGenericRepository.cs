using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class CategoryGenericRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryGenericRepository(ManGnurtDbContext dbContext) : base(dbContext)
        {
        }

      
    }
}
