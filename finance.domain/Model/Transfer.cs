namespace backend.finance.domain.Model
{
    public class Transfer
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public double Amount { get; set; }
        public Account AccountId { get; set; }
        public User UserId { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<User> Users { get; set; } = new List<User>();

        protected Transfer()
        {
            
        }

        public Transfer(DateTime createdAt, double amount)
        {
            CreatedAt = createdAt;
            Amount = amount;

        }
    }
}
