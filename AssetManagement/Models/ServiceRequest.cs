namespace AssetManagement.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; } // PK
        public int AssetId { get; set; }          // FK → Asset
        public int EmployeeId { get; set; }       // FK → Employee
        public string IssueType { get; set; } = string.Empty;     // Repair, Malfunction
        public string Description { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
        public int StatusId { get; set; }         // FK → ServiceStatusMaster
        public string AdminRemarks { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }

        public Asset? Asset { get; set; }
        public Employee? Employee { get; set; }
        public ServiceStatusMaster? Status { get; set; }
    }
}
