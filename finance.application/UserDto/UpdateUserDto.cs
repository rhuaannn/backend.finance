namespace backend.finance.application.UserDto
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UpdateUserDto(Guid id, string name, string email, string cpf, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            CPF = cpf;
            Password = password;
        }
    }
}
