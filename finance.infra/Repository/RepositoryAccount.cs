using backend.finance.domain.Model;
using backend.finance.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.finance.infra.Repository
{
    public class RepositoryAccount : IAccountRepository
    {
        private readonly Connection _context;

        public RepositoryAccount(Connection connection)
        {
            _context = connection;

        }
        public async Task<Account> CreateAccount(Account account)
        {
           var createdAccount = await _context.Accounts.AddAsync(account);
             await _context.SaveChangesAsync();
            return createdAccount.Entity;
        }

        public async Task<Account?> GetAccountById(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
      
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }


        public async Task<Account> UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

    }
}
