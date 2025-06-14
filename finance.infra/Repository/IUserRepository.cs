using backend.finance.domain.Model;

namespace backend.finance.infra.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(Guid id);
        Task<User?> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task<User?> UpdateUser(User user);

    }
}
