using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAssetService
    {
        Task<Asset?> GetAssetByIdAsync(int assetId);
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task<Asset> AddAssetAsync(Asset asset);
        Task<Asset> UpdateAssetAsync(Asset asset);
        Task<bool> DeleteAssetAsync(int assetId);
        Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(int categoryId);
        Task<IEnumerable<Asset>> GetAssetsByStatusAsync(int statusId);
    }
}
