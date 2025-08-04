namespace AssetManagement.Models
{
    public class Asset
    {
        public int AssetId { get; set; }          // PK
        public string AssetNo { get; set; } = string.Empty;       // Unique
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public int CategoryId { get; set; }       // FK → AssetCategory
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float AssetValue { get; set; }
        public int StatusId { get; set; }         // FK → AssetStatusMaster
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public AssetCategory Category { get; set; }
        public AssetStatusMaster Status { get; set; }
        public ICollection<AssetAllocation?> AssetAllocations { get; set; }
        public ICollection<ServiceRequest?> ServiceRequests { get; set; }
        public ICollection<AuditRequest?> AuditRequests { get; set; }
    }
}
