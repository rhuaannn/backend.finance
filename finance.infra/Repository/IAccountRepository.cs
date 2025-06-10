using backend.finance.domain.Model;

namespace backend.finance.infra.Repository
{
    public interface IAccountRepository
    {
        Task<Account> CreateAccount (Account account);
        Task<Account?> GetAccountById(Guid id);
        Task<List<Account>> GetAllAccounts();
        Task<Account> UpdateAccount(Account account);


    }
}
