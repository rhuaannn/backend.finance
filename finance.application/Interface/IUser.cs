using backend.finance.application.UserDto;

namespace backend.finance.application.Interface
{
    public interface IUser
    {
        public Task<ResponseUserDto> CreateUserAsync(CreateUserDto userDto);
        public Task<ResponseUserDto> UpdateUserAsync(Guid id, UpdateUserDto userDto);
        public Task<List<ResponseUserDto>> GetAllUserAsync ();
    }
}
