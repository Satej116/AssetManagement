namespace AssetManagement.Models.DTOs.Auth
{
    public class TokenUserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
