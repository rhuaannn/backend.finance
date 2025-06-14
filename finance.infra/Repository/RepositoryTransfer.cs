using backend.finance.domain.Model;
using backend.finance.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.finance.infra.Repository;

public class RepositoryTransfer : ITransferAccountRepository
{
    private readonly Connection _context;
    public RepositoryTransfer(Connection context)
    {
        _context = context;
    }
    public Task<Transfer> CreateTransferAccount(Transfer transfer)
    {
       var transferAccount = _context.Transfers.Add(transfer);
        _context.SaveChanges();
        return Task.FromResult(transferAccount.Entity);
    }

    public async Task<List<Transfer>> RegisterAccountTransfer(Guid accountId)
    {
        var transfers = await _context.Transfers
            .Include(t => t.SourceAccount)
            .Include(t => t.DestinationAccount)
            .Where(t => t.SourceAccountId == accountId || t.DestinationAccountId == accountId)
            .ToListAsync();

        return transfers;
    }
}