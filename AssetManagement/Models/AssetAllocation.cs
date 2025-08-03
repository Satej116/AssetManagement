namespace AssetManagement.Models
{
    public class AssetAllocation
    {
        public int AssetId { get; set; }          // PK + FK → Asset
        public int EmployeeId { get; set; }       // PK + FK → Employee
        public DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "assigned";
        public string Notes { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation
        public Asset Asset { get; set; }
        public Employee Employee { get; set; }
    }
}
