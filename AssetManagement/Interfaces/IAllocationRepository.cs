using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAllocationRepository : IRepository<(int assetId, int employeeId), AssetAllocation>
    {
        Task<AssetAllocation?> GetAllocationAsync(int assetId, int employeeId);
        Task<IEnumerable<AssetAllocation>> GetAllocationsByEmployeeAsync(int employeeId);
        Task<IEnumerable<AssetAllocation>> GetAllocationsByAssetAsync(int assetId);
    }
}
