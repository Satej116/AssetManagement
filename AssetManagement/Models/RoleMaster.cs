
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class RoleMaster
    {
        [Key]
        public int RoleId { get; set; }           // PK
        public string RoleName { get; set; } = string.Empty;     // Admin, Employee

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Employee> Employees { get; set; }
    }
}
