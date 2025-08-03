using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories.DB
{
    public class UserRepositoryDb
         : RepositoryDb<int, User>, IUserRepository
    {
        public UserRepositoryDb(AssetManagementDbContext context) : base(context)
        {
        }

        // Override generic GetByIdAsync with includes
        public override async Task<User?> GetByIdAsync(int userId)
        {
            return await _dbSet
                         .Include(u => u.Employee)
                         .Include(u => u.Role)
                         .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        // IUserRepository specific methods
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await GetByIdAsync(userId);
        }

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
        {
            return await AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await UpdateAsync(user.UserId, user);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await GetByIdAsync(userId);
            if (user == null) return false;

            await DeleteAsync(userId);
            return true;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _dbSet.AnyAsync(u => u.Username == username);
        }
    }
}
