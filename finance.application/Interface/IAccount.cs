using backend.finance.application.AccountDto;

namespace backend.finance.application.Interface
{
    public interface IAccount
    {
        Task<ResponseAccountDto> CreateAccount(CreateAccountDto dto);
        Task<ResponseAccountDto> UpdateAccount(Guid id, UpdateAccountDto dto);
        Task<ResponseAccountDto> GetAccountById(Guid id);
        Task<List<ResponseAccountDto>> GetAllAccounts();
    }


}
