using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using Microsoft.EntityFrameworkCore;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ManGnurtDbContext dbContext) : base(dbContext) { }

        public override async Task<Account> Insert(Account entity)
        {
            if (string.IsNullOrEmpty(entity.UserName))
                throw new AccountException("UserName is required.");

            if (string.IsNullOrEmpty(entity.Password))
                throw new AccountException("Password is required.");

            var isDuplicate = await _dbSet.AnyAsync(a => a.UserName == entity.UserName);
            if (isDuplicate)
                throw new AccountException("UserName already exists.");

            return await base.Insert(entity);
        }
    }
}
