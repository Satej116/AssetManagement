using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class UserRepository
        : RepositoryDb<int, User>, IUserRepository
    {
        public UserRepository(AssetManagementDbContext context) : base(context)
        {
        }

        public override async Task<User?> GetByIdAsync(int userId)
        {
            return await _dbSet
                         .Include(u => u.Employee)
                         .Include(u => u.Role)
                         .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
            => await GetByIdAsync(userId);

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbSet
                         .Include(u => u.Employee)
                         .Include(u => u.Role)
                         .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbSet
                         .Include(u => u.Employee)
                         .Include(u => u.Role)
                         .ToListAsync();
        }

        public async Task<User> AddUserAsync(User user)
            => await AddAsync(user);

        public async Task<User> UpdateUserAsync(User user)
            => await UpdateAsync(user.UserId, user);

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await GetByIdAsync(userId);
            if (user == null) return false;

            await DeleteAsync(userId);
            return true;
        }

        public async Task<bool> UserExistsAsync(string username)
            => await _dbSet.AnyAsync(u => u.Username == username);
    }
}

