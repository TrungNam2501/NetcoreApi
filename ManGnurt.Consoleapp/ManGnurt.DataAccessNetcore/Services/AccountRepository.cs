using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.EntityFrameworkCore;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ManGnurtDbContext dbContext) : base(dbContext) { }

        public async Task<List<Account>> GetList(Account_GetListRequestData requestData)
        {
            var query = _dbSet.AsQueryable();

            if (requestData != null)
            {
                if (requestData.AccountID.HasValue && requestData.AccountID.Value > 0)
                {
                    query = query.Where(x => x.AccountID == requestData.AccountID.Value);
                }

                if (!string.IsNullOrEmpty(requestData.UserName))
                {
                    query = query.Where(x => x.UserName != null
                        && x.UserName.Contains(requestData.UserName));
                }
            }

            return await query.ToListAsync();
        }

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

        public override async Task<Account> Update(Account entity)
        {
            if (entity.AccountID <= 0)
                throw new AccountException("Account ID is not valid.");

            var existing = await _dbSet.FindAsync(entity.AccountID);
            if (existing == null)
                throw new AccountException("Account not found.");

            if (string.IsNullOrEmpty(entity.UserName))
                throw new AccountException("UserName is required.");

            var isDuplicate = await _dbSet.AnyAsync(a => a.UserName == entity.UserName && a.AccountID != entity.AccountID);
            if (isDuplicate)
                throw new AccountException("UserName already exists.");

            existing.UserName = entity.UserName;
            existing.Password = entity.Password;
            existing.Address = entity.Address;

            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public override async Task Delete(int id)
        {
            if (id <= 0)
                throw new AccountException("Account ID is not valid.");

            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new AccountException("Account not found.");

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
