using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;
using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await SaveChangesAsync();
            return user;
        }

        public Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            return SaveChangesAsync();
        }

        public Task<IEnumerable<User>> GetAllAsync() =>
            Task.FromResult(_context.Users.AsEnumerable());

        public Task<User?> GetByIdAsync(int id) =>
            _context.Users.FindAsync(id).AsTask();

        public Task<User?> GetUserByEmailAsync(string email) =>
            _context.Users.FirstOrDefaultAsync(u => u.email == email);

        public Task SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
