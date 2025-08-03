namespace AssetManagement.Models
{
    public class AssetCategory
    {
        public int AssetCategoryId { get; set; }       // PK
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Navigation
        public ICollection<Asset> Assets { get; set; }
    }
}
