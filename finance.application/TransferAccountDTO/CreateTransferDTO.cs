public class CreateTransferDTO
{
    public decimal Amount { get; set; }
    public Guid SourceAccountId { get; set; }
    public Guid DestinationAccountId { get; set; }
    public Guid UserId { get; set; }

    protected CreateTransferDTO() {}

    public CreateTransferDTO(decimal amount, Guid sourceAccountId, Guid destinationAccountId, Guid userId)
    {
        Amount = amount;
        SourceAccountId = sourceAccountId;
        DestinationAccountId = destinationAccountId;
        UserId = userId;
    }
}