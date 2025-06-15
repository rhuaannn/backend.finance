using backend.finance.domain.ValueObjects;

namespace backend.finance.domain.Model
{
    public class User : Entity
    {
        public string Name { get; set; } = string.Empty;
        public CPF CPF { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public IEnumerable<Account> Accounts { get; set; }
        public ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();

        protected User()
        {
            
        }
        public User(string name, CPF cpf, Email email, string password)
        {
            Name = name;
            CPF = cpf;
            Email = email;
            Password = password;
            
        }
    }
}
