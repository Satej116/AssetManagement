using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class ServiceStatusMaster
    {
        [Key]
        public int StatusId { get; set; }         // PK
        public string StatusName { get; set; } = string.Empty;   // Pending, InProgress, Resolved, Rejected

        // Navigation
        public ICollection<ServiceRequest?> ServiceRequests { get; set; }
    }
}
