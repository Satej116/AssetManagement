using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IUserRepository : IRepository<int, User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> UserExistsAsync(string username);
    }
}
