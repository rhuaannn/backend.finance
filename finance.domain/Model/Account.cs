namespace backend.finance.domain.Model
{
        public class Account : Entity
    {
         
            public int AgencyId { get; set; }
            public int AccountId { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
            public User User { get; set; }
            public Guid UserId { get; set; } 
            public decimal Balance { get; set; }
            public ICollection<Transfer> Transfers { get; set; }

        protected Account()
        { 
        }
        public Account(int agencyId, int accountId,DateTime createdAt, DateTime updatedAt, decimal balance, Guid userId)
        {
            AgencyId = agencyId;
            AccountId = accountId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Balance = balance;
            UserId = userId;
        }
    }
}
