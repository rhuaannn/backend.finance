using backend.finance.application.AccountDto;
using backend.finance.application.Interface;
using backend.finance.application.Mapping;
using backend.finance.domain.Model;
using backend.finance.infra.Repository;

namespace backend.finance.application.Service
{
    public class AccountServices : IAccount
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly MapToAccount _mapToAccount;
 
        public AccountServices(IAccountRepository accountRepository, IUserRepository userRepository, MapToAccount mapToAccount)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _mapToAccount = mapToAccount;
        }
        public async Task<Account> CreateAccount(CreateAccountDto dto)
        {
            var user = await _userRepository.GetUserById(dto.UserId);
            if(user == null) throw new Exception("Usuário não encontrado.");
            var account = _mapToAccount.MapAccount(dto);
            if(account.Balance < 0) throw new Exception("Saldo inicial não pode ser negativo.");
            return await _accountRepository.CreateAccount(account);
        }
        public async Task<Account> UpdateAccount(Guid id, UpdateAccountDto dto)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null) throw new Exception("Conta não encontrada.");
            account = _mapToAccount.MapAccount(account, dto);
            return await _accountRepository.UpdateAccount(account);
        }
        public async Task<Account> GetAccountById(Guid id)
        {
            return await _accountRepository.GetAccountById(id);
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAllAccounts();
        }
    }
}
