using System.ComponentModel.DataAnnotations;
namespace AssetManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }       // PK
        public int RoleId { get; set; }           // FK → RoleMaster

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }  
        public string Address { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public RoleMaster? Role { get; set; }
        public User? User { get; set; }
        public ICollection<AssetAllocation?> AssetAllocations { get; set; }
        public ICollection<ServiceRequest?> ServiceRequests { get; set; }
        public ICollection<AuditRequest?> AuditRequests { get; set; }
        public ICollection<AdminLog?> AdminLogs { get; set; }


    }
}
