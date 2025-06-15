using backend.finance.application.Interface;
using backend.finance.application.Mapping;
using backend.finance.application.UserDto;
using backend.finance.domain.Model;
using backend.finance.infra.Repository;

namespace backend.finance.application.Service
{
    public class UserServices : IUser
    {
        private readonly IUserRepository _userRepository;
        private readonly MapToUser _mapToUser;
        public UserServices(IUserRepository userRepository, MapToUser mapToUser)
        {
            _mapToUser = mapToUser;
            _userRepository = userRepository;
        }
        public async Task<ResponseUserDto> CreateUserAsync(CreateUserDto userDto)
        {
           var createdUser = _mapToUser.MapUser(userDto);
          
            var user = await _userRepository.CreateUser(createdUser);
            if (user == null)
            {
                throw new Exception("Failed to create user.");
            }
            return _mapToUser.MapToUserResponseDTO(user);
        }

        public async Task<List<ResponseUserDto>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllUsers();
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException("No users found.");
            }
            return _mapToUser.MapToUserResponseDTOList(users);
        }

        public async Task<ResponseUserDto> UpdateUserAsync(Guid id, UpdateUserDto userDto)
        {
            var existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            var updatedUser = _mapToUser.MapUser(existingUser, userDto);
            var result = await _userRepository.UpdateUser(updatedUser);
            return _mapToUser.MapToUserResponseDTO(result) ?? throw new Exception("Failed to update user.");
        }

       
    }
}
