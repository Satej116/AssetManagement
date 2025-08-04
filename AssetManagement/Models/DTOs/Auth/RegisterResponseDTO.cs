namespace AssetManagement.Models.DTOs.Auth
{
    public class RegisterResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
