using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories.DB
{
    public class AllocationRepositoryDb
        : RepositoryDb<(int, int), AssetAllocation>, IAllocationRepository
    {
        public AllocationRepositoryDb(AssetManagementDbContext context) : base(context)
        {
        }

        // Override GetByIdAsync for composite key (AssetId, EmployeeId)
        public override async Task<AssetAllocation?> GetByIdAsync((int, int) key)
        {
            var (assetId, employeeId) = key;
            return await _dbSet
                         .Include(a => a.Asset)
                         .Include(a => a.Employee)
                         .FirstOrDefaultAsync(a => a.AssetId == assetId && a.EmployeeId == employeeId);
        }

        // IAllocationRepository Methods
        public async Task<AssetAllocation?> GetAllocationAsync(int assetId, int employeeId)
        {
            return await GetByIdAsync((assetId, employeeId));
        }

        public async Task<IEnumerable<AssetAllocation>> GetAllAllocationsAsync()
        {
            return await _dbSet
                         .Include(a => a.Asset)
                         .Include(a => a.Employee)
                         .ToListAsync();
        }

        public async Task<AssetAllocation> AddAllocationAsync(AssetAllocation allocation)
        {
            return await AddAsync(allocation);
        }

        public async Task<AssetAllocation> UpdateAllocationAsync(AssetAllocation allocation)
        {
            return await UpdateAsync((allocation.AssetId, allocation.EmployeeId), allocation);
        }

        public async Task<bool> DeleteAllocationAsync(int assetId, int employeeId)
        {
            var allocation = await GetByIdAsync((assetId, employeeId));
            if (allocation == null) return false;

            await DeleteAsync((assetId, employeeId));
            return true;
        }

        public async Task<IEnumerable<AssetAllocation>> GetAllocationsByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                         .Where(a => a.EmployeeId == employeeId)
                         .Include(a => a.Asset)
                         .ToListAsync();
        }

        public async Task<IEnumerable<AssetAllocation>> GetAllocationsByAssetAsync(int assetId)
        {
            return await _dbSet
                         .Where(a => a.AssetId == assetId)
                         .Include(a => a.Employee)
                         .ToListAsync();
        }
    }
}
