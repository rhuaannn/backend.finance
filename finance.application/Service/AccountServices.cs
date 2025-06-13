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
        private readonly MapToAccount _mapToAccount;
        
 
        public AccountServices(IAccountRepository accountRepository, IUserRepository userRepository, MapToAccount mapToAccount)
        {
            _accountRepository = accountRepository;
            _mapToAccount = mapToAccount;
        }

        public async Task<ResponseAccountDto> CreateAccount(CreateAccountDto dto)
        {
            var account = _mapToAccount.MapAccount(dto);
            var createdAccount = await _accountRepository.CreateAccount(account);
            return _mapToAccount.MapToResponseDto(createdAccount);
        }

        public async Task<ResponseAccountDto> GetAccountById(Guid id)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {id} not found.");
            }
            return _mapToAccount.MapToResponseDto(account);

        }

        public async Task<List<ResponseAccountDto>> GetAllAccounts()
        {
            var accounts = await _accountRepository.GetAllAccounts();
         
            return _mapToAccount.MapToResponseDtoList(accounts);
        }

        public async Task<ResponseAccountDto> UpdateAccount(Guid id, UpdateAccountDto dto)
        {
            var existingAccount = await _accountRepository.GetAccountById(id);
            if (existingAccount == null)
            {
                throw new KeyNotFoundException($"Account with ID {id} not found.");
            }
            var updatedAccount = _mapToAccount.MapAccount(existingAccount, dto);

            var result = await _accountRepository.UpdateAccount(updatedAccount);
            if (result == null)
            {
                throw new Exception("Failed to update account.");
            }
            return _mapToAccount.MapToResponseDto(result);
        }

   
    }
}
