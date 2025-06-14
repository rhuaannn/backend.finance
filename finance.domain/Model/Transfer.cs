namespace backend.finance.domain.Model
{
    public class Transfer : Entity
    {
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public decimal Amount { get; set; }

        public Guid SourceAccountId { get; set; }
        public Account SourceAccount { get; set; }

        public Guid DestinationAccountId { get; set; }
        public Account DestinationAccount { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        protected Transfer()
        {
        }

        public Transfer(decimal amount, Guid sourceAccountId, Guid destinationAccountId, Guid userId)
        {
            Amount = amount;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            UserId = userId;
        }
    }
}