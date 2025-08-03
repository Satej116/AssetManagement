namespace AssetManagement.Models
{
    public class User
    {
        public int UserId { get; set; }             // PK
        public int EmployeeId { get; set; }         // FK → Employees
        public string Username { get; set; }        // Unique username or email
        public string PasswordHash { get; set; }    // Hashed password
        public int RoleId { get; set; }             // FK → RoleMaster
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public Employee? Employee { get; set; }
        public RoleMaster? Role { get; set; }
    }
}
