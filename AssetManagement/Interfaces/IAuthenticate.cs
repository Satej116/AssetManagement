using AssetManagement.Models;
using AssetManagement.Models.DTOs.Auth;

namespace AssetManagement.Interfaces
{
    public interface IAuthenticate
    {
        Task<RegisterResponseDTO> Register(RegisterRequestDTO request);
        Task<LoginResponseDTO> Login(LoginRequestDTO request);
    }
}
