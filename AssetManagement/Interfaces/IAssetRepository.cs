using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAssetRepository : IRepository<int, Asset>
    {
        Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(int categoryId);
        Task<IEnumerable<Asset>> GetAssetsByStatusAsync(int statusId);
    }
}
