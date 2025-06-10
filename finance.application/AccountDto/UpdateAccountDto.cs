namespace backend.finance.application.AccountDto
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }
        public int AgencyId { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
    }
}
