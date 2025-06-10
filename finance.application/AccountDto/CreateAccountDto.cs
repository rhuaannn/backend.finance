namespace backend.finance.application.AccountDto
{
    public class CreateAccountDto
    {
        public decimal Balance { get; set; }
        public int AgencyId { get; set; }
        public int AccountId { get; set; }
        public Guid UserId { get; set; }
        protected CreateAccountDto()
        {
            
        }
        public CreateAccountDto(decimal balance, int agencyId, int accountId, Guid userId)
        {
            AgencyId = agencyId;
            AccountId = accountId;
            Balance = balance;
            UserId = userId;

        }
    }
}
