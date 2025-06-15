using System.ComponentModel.DataAnnotations;

namespace backend.finance.application.AccountDto
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
