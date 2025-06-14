using backend.finance.domain.Model;

namespace backend.finance.infra.Repository;

public interface ITransferAccountRepository
{
    Task<Transfer> CreateTransferAccount (Transfer transfer);
    Task<List<Transfer>> RegisterAccountTransfer(Guid accountId);
}