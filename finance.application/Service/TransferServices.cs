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
            throw new ArgumentException("Conta origem ou destino não encontrada.");

        if (dto.Amount <= 0)
            throw new ArgumentException("Valor da transferência deve ser maior que zero.");

        if (dto.SourceAccountId == dto.DestinationAccountId)
            throw new ArgumentException("Não é permitido transferir para a mesma conta.");

        if (sourceAccount.Balance < dto.Amount)
            throw new InvalidOperationException("Saldo insuficiente na conta de origem.");

        // Atualiza os saldos
        sourceAccount.Balance -= dto.Amount;
        destinationAccount.Balance += dto.Amount;

        // Persiste as atualizações nas contas
        await _accountRepository.UpdateAccount(sourceAccount);
        await _accountRepository.UpdateAccount(destinationAccount);

        // Cria o registro da transferência
        var transfer = new Transfer(dto.Amount, dto.SourceAccountId, dto.DestinationAccountId, dto.UserId);
        var createdTransfer = await _transferAccountRepository.CreateTransferAccount(transfer);

        return createdTransfer;
    }


    public async Task<List<Transfer>> HistoryTransferAccount(Guid accountId)
    {
        return await _transferAccountRepository.RegisterAccountTransfer(accountId);
    }
}
