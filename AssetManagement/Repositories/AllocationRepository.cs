using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class AllocationRepository : RepositoryDb<(int, int), AssetAllocation>, IAllocationRepository
    {
        public AllocationRepository(AssetManagementDbContext context) : base(context) { }

        public async Task<AssetAllocation?> GetAllocationAsync(int assetId, int employeeId)
        {
            return await _dbSet
                         .Include(a => a.Asset)
                         .Include(a => a.Employee)
                         .FirstOrDefaultAsync(a => a.AssetId == assetId && a.EmployeeId == employeeId);
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

        // Override methods for generic repository
        public override async Task<AssetAllocation?> GetByIdAsync((int, int) key)
        {
            return await GetAllocationAsync(key.Item1, key.Item2);
        }

        public override async Task<IEnumerable<AssetAllocation>> GetAllAsync()
        {
            return await _dbSet
                         .Include(a => a.Asset)
                         .Include(a => a.Employee)
                         .ToListAsync();
        }
    }
}
