namespace AssetManagement.Models.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }  // Simple, consistent naming

        public string FirstName { get; set; } =string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int RoleId { get; set; }  // If linked to RoleMaster
        public string RoleName { get; set; } = string.Empty;  // Optional for output


    }
}
