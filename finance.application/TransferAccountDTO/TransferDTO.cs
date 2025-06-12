namespace backend.finance.application.TransferAccountDTO;

public class TransferDTO
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }        
    public Guid SourceAccountId { get; set; } 
    public Guid DestinationAccountId { get; set; }
    
    protected TransferDTO()
    {
        
    }
    public TransferDTO(Guid id, decimal amount, DateTime date, Guid sourceAccountId, Guid destinationAccountId)
    {
        Id   = id;
        Amount = amount;
        Date = date;
        SourceAccountId = sourceAccountId;
        DestinationAccountId = destinationAccountId;
    }
}