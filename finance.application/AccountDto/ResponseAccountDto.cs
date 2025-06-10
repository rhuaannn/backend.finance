namespace backend.finance.application.AccountDto
{
    public class ResponseAccountDto
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public int AgencyId { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public ResponseAccountDto(Guid id, decimal balance, int agencyId, int accountId, DateTime createdAt, Guid userId)
        {
            Id = id;
            Balance = balance;
            AgencyId = agencyId;
            AccountId = accountId;
            CreatedAt = createdAt;
            UserId = userId;
        }
    }
}
