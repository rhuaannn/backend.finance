using backend.finance.application.UserDto;
using backend.finance.domain.Model;
using backend.finance.domain.ValueObjects;

namespace backend.finance.application.Mapping
{
    public class MapToUser
    {
        public User MapUser(CreateUserDto dto)
        {
            var cpf = new CPF(dto.CPF);
            var email = new Email(dto.Email);

            return new User(dto.Name, cpf, email, dto.Password);
        }

        public ResponseUserDto MapToUserResponseDTO(User user)
        {
            return new ResponseUserDto(
                user.Id,
                user.Name,
                user.Email.EmailAddress,
                user.CPF.Number,    
                user.CreatedAt,
                user.UpdatedAt
            );
        }
        public User MapUser(User user, UpdateUserDto dto)
        {
            user.Name = dto.Name;
            user.Email = new Email(dto.Email);
            user.CPF = new CPF(dto.CPF);
            user.Password = dto.Password;
            user.UpdatedAt = DateTime.UtcNow;

            return user;
        }
        public List<ResponseUserDto> MapToUserResponseDTOList(List<User> users)
        {
            return users.Select(MapToUserResponseDTO).ToList();
        }


    }
}
