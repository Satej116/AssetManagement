using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAllocationService
    {
        Task<AssetAllocation?> GetAllocationAsync(int assetId, int employeeId);
        Task<IEnumerable<AssetAllocation>> GetAllAllocationsAsync();
        Task<AssetAllocation> AddAllocationAsync(AssetAllocation allocation);
        Task<AssetAllocation> UpdateAllocationAsync(AssetAllocation allocation);
        Task<bool> DeleteAllocationAsync(int assetId, int employeeId);
        Task<IEnumerable<AssetAllocation>> GetAllocationsByEmployeeAsync(int employeeId);
        Task<IEnumerable<AssetAllocation>> GetAllocationsByAssetAsync(int assetId);
    }
}
