using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IServiceRequestService
    {
        Task<ServiceRequest?> GetServiceRequestByIdAsync(int requestId);
        Task<IEnumerable<ServiceRequest>> GetAllServiceRequestsAsync();
        Task<ServiceRequest> AddServiceRequestAsync(ServiceRequest request);
        Task<ServiceRequest> UpdateServiceRequestAsync(ServiceRequest request);
        Task<bool> DeleteServiceRequestAsync(int requestId);
        Task<IEnumerable<ServiceRequest>> GetServiceRequestsByEmployeeAsync(int employeeId);
        Task<IEnumerable<ServiceRequest>> GetServiceRequestsByAssetAsync(int assetId);
    }
}

