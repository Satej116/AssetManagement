using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IServiceRequestRepository : IRepository<int, ServiceRequest>
    {
        Task<IEnumerable<ServiceRequest>> GetServiceRequestsByEmployeeAsync(int employeeId);
        Task<IEnumerable<ServiceRequest>> GetServiceRequestsByAssetAsync(int assetId);
    }

}

