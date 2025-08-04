namespace AssetManagement.Models
{
    public class AuditRequest
    {
        public int AuditRequestId { get; set; }   // PK
        public int AssetId { get; set; }          // FK → Asset
        public int EmployeeId { get; set; }       // FK → Employee
        public DateTime RequestDate { get; set; }
        public int StatusId { get; set; }         // FK → AuditStatusMaster
        public string Remarks { get; set; } = string.Empty;
        public DateTime? VerifiedDate { get; set; }

        public Asset? Asset { get; set; }
        public Employee? Employee { get; set; }
        public AuditStatusMaster? Status { get; set; }
    }
}
