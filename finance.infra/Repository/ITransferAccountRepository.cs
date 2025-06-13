using backend.finance.domain.Model;

namespace backend.finance.infra.Repository;

public interface ITransferAccount
{
    Task<Transfer> CreateTransferAccount (Transfer transfer);
}