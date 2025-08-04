namespace AssetManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string HashKey { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public Employee? Employee { get; set; } = null!;
        public RoleMaster? Role { get; set; } = null!;

    }
}
