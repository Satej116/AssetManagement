using System.ComponentModel.DataAnnotations;
namespace AssetManagement.Models
{
    public class AuditStatusMaster
    {
        [Key]
        public int AuditStatusId { get; set; }         // PK
        public string StatusName { get; set; } = string.Empty;  // Pending, Verified, Rejected

        // Navigation
        public ICollection<AuditRequest?> AuditRequests { get; set; }
    }
}
