namespace AssetManagement.Models.DTOs
{
    public class AssetDTO
    {
        public int AssetId { get; set; }
        public string AssetNo { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string AssetModel { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AssetValue { get; set; }
        public int StatusId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;

    }
}
