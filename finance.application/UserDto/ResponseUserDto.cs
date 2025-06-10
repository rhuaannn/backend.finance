namespace backend.finance.application.UserDto
{
    public class ResponseUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ResponseUserDto(Guid id, string name, string email, string cpf, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            CPF = cpf;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
