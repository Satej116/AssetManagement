namespace AssetManagement.Models
{
    public class AdminLog
    {
        public int AdminLogId { get; set; }            // PK
        public int AdminId { get; set; }          // FK → Employee
        public string Action { get; set; } = string.Empty;
        public string EntityAffected { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        // Navigation
        public Employee Admin { get; set; }
    }
}
