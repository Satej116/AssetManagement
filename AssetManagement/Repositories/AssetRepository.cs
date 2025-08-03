using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class AssetRepository : RepositoryDb<int, Asset>, IAssetRepository
    {
        public AssetRepository(AssetManagementDbContext context) : base(context) { }

        // Override generic GetByIdAsync with navigation properties
        public override async Task<Asset?> GetByIdAsync(int assetId)
        {
            return await _dbSet
                         .Include(a => a.Category)
                         .Include(a => a.Status)
                         .FirstOrDefaultAsync(a => a.AssetId == assetId);
        }

        // Override generic GetAllAsync with navigation properties
        public override async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _dbSet
                         .Include(a => a.Category)
                         .Include(a => a.Status)
                         .ToListAsync();
        }

        // Custom methods from IAssetRepository
        public async Task<Asset?> GetAssetByIdAsync(int assetId)
        {
            return await GetByIdAsync(assetId);
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Asset> AddAssetAsync(Asset asset)
        {
            return await AddAsync(asset);
        }

        public async Task<Asset> UpdateAssetAsync(Asset asset)
        {
            return await UpdateAsync(asset.AssetId, asset);
        }

        public async Task<bool> DeleteAssetAsync(int assetId)
        {
            var asset = await GetByIdAsync(assetId);
            if (asset == null) return false;

            await DeleteAsync(assetId);
            return true;
        }

        public async Task<IEnumerable<Asset>> GetAssetsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                         .Where(a => a.CategoryId == categoryId)
                         .Include(a => a.Status)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetAssetsByStatusAsync(int statusId)
        {
            return await _dbSet
                         .Where(a => a.StatusId == statusId)
                         .Include(a => a.Category)
                         .ToListAsync();
        }
    }
}
