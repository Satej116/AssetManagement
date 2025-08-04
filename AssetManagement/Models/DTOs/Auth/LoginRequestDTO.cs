namespace AssetManagement.Models.DTOs.Auth
{
    public class LoginRequestDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string HashKey { get; set; } = string.Empty;
    }
}
