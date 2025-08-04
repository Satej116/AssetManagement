using AssetManagement.Models;
using AssetManagement.Models.DTOs.Auth;

namespace AssetManagement.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(TokenUserDTO user);
    }
}
