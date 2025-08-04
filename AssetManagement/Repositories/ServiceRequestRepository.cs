using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class ServiceRequestRepository
        : RepositoryDb<int, ServiceRequest>, IServiceRequestRepository
    {
        public ServiceRequestRepository(AssetManagementDbContext context) : base(context)
        {
        }

        public override async Task<ServiceRequest?> GetByIdAsync(int requestId)
        {
            return await _dbSet
                         .Include(sr => sr.Asset)
                         .Include(sr => sr.Employee)
                         .Include(sr => sr.Status)
                         .FirstOrDefaultAsync(sr => sr.ServiceRequestId == requestId);
        }

        public async Task<ServiceRequest?> GetServiceRequestByIdAsync(int requestId)
        {
            return await GetByIdAsync(requestId);
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllServiceRequestsAsync()
        {
            return await _dbSet
                         .Include(sr => sr.Asset)
                         .Include(sr => sr.Employee)
                         .Include(sr => sr.Status)
                         .ToListAsync();
        }

        public async Task<ServiceRequest> AddServiceRequestAsync(ServiceRequest request)
        {
            return await AddAsync(request);
        }

        public async Task<ServiceRequest> UpdateServiceRequestAsync(ServiceRequest request)
        {
            return await UpdateAsync(request.ServiceRequestId, request);
        }

        public async Task<bool> DeleteServiceRequestAsync(int requestId)
        {
            var request = await GetByIdAsync(requestId);
            if (request == null) return false;

            await DeleteAsync(requestId);
            return true;
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestsByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                         .Where(sr => sr.EmployeeId == employeeId)
                         .Include(sr => sr.Asset)
                         .Include(sr => sr.Status)
                         .ToListAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestsByAssetAsync(int assetId)
        {
            return await _dbSet
                         .Where(sr => sr.AssetId == assetId)
                         .Include(sr => sr.Employee)
                         .Include(sr => sr.Status)
                         .ToListAsync();
        }
    }
}
