using backend.finance.domain.Model;
using backend.finance.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.finance.infra.Repository
{
    public class RepositoyUser : IUserRepository
    {
        private readonly Connection _context;
        public RepositoyUser(Connection context)
        {
            _context = context;
            
        }
        public async Task<User> CreateUser(User user)
        {
            var createUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return createUser.Entity;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.EmailAddress == email);
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateUser(User user)
        {
           _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;

        }
    }
}
