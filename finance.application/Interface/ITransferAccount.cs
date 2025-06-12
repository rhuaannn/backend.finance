using backend.finance.domain.Model;
using backend.finance.application.TransferAccountDTO;
namespace backend.finance.application.Interface;

public interface ITransferAccount
{
    Task<Transfer> TransferAccount(TransferDTO dto);
    Task<Transfer> HistoryTransferAccount(TransferDTO dto);
} 