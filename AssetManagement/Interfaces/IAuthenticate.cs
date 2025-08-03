using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAuthenticate
    {
        Task<User?> RegisterAsync(User user, string password);
        Task<User?> LoginAsync(string username, string password);
        Task<bool> UserExistsAsync(string username);
    }
}
