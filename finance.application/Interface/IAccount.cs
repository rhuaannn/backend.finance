using backend.finance.application.AccountDto;
using backend.finance.domain.Model;

namespace backend.finance.application.Interface
{
    public interface IAccount
    {
        Task<Account> CreateAccount(CreateAccountDto dto);
        Task<Account> UpdateAccount(Guid id, UpdateAccountDto dto);
        Task<Account> GetAccountById(Guid id);
        Task<List<Account>> GetAllAccounts();   
    }
}
