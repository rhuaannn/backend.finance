using backend.finance.application.AccountDto;
using backend.finance.domain.Model;
namespace backend.finance.application.Mapping
{

    public class MapToAccount
    {
        public Account MapAccount(CreateAccountDto dto)
        {
            return new Account(
                dto.AgencyId,
                dto.AccountId,
                DateTime.UtcNow,
                DateTime.UtcNow,
                dto.Balance,
                dto.UserId
            );
        }

        public Account MapAccount(Account account, UpdateAccountDto dto)
        {
            account.AgencyId = dto.AgencyId;
            account.AccountId = dto.AccountId;
            account.Balance = dto.Balance;
            account.UpdatedAt = DateTime.UtcNow;

            return account;
        }

        public ResponseAccountDto MapToResponseDto(Account account)
        {
            return new ResponseAccountDto(
                account.Id,
                account.Balance,
                account.AgencyId,
                account.AccountId,
                account.CreatedAt,
                account.UserId
            );
        }

        public List<ResponseAccountDto> MapToResponseDtoList(List<Account> accounts)
        {
            return accounts.Select(MapToResponseDto).ToList();
        }
    }

}
