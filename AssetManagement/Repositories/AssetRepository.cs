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
        public override async Task<Asset?> GetByIdAsync(int assetId)
        {
            return await _dbSet
                         .Include(a => a.Category)
                         .Include(a => a.Status)
                         .FirstOrDefaultAsync(a => a.AssetId == assetId);
        }

        public override async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _dbSet
                         .Include(a => a.Category)
                         .Include(a => a.Status)
                         .ToListAsync();
        }
    }
}
