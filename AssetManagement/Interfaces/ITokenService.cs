using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
