using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IUserRepository : IRepository<int, User>
    {
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> UserExistsAsync(string username);
    }
}
