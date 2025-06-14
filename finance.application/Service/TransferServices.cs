using backend.finance.application.Interface;
using backend.finance.domain.Model;
using backend.finance.infra.Repository;

namespace backend.finance.application.Service;

public class TransferAccountService : ITransferAccount
{
    private readonly ITransferAccountRepository _transferAccountRepository;
    private readonly IAccountRepository _accountRepository;

    public TransferAccountService(ITransferAccountRepository transferAccountRepository, IAccountRepository accountRepository)
    {
        _transferAccountRepository = transferAccountRepository;
        _accountRepository = accountRepository;
    }

    public async Task<Transfer> TransferAccount(CreateTransferDTO dto)
    {
        var sourceAccount = await _accountRepository.GetAccountById(dto.SourceAccountId);
        var destinationAccount = await _accountRepository.GetAccountById(dto.DestinationAccountId);

        if (sourceAccount == null || destinationAccount == null)
            throw new ArgumentException("Conta origem ou destino n�o encontrada.");

        if (dto.Amount <= 0)
            throw new ArgumentException("Valor da transfer�ncia deve ser maior que zero.");

        if (dto.SourceAccountId == dto.DestinationAccountId)
            throw new ArgumentException("N�o � permitido transferir para a mesma conta.");

        var transfer = new Transfer(dto.Amount, dto.SourceAccountId, dto.DestinationAccountId, dto.UserId);

        return await _transferAccountRepository.CreateTransferAccount(transfer);
    }

    public async Task<List<Transfer>> HistoryTransferAccount(Guid accountId)
    {
        return await _transferAccountRepository.RegisterAccountTransfer(accountId);
    }
}
