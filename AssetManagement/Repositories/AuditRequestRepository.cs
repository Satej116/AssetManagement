using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class AuditRequestRepository
        : RepositoryDb<int, AuditRequest>, IAuditRequestRepository
    {
        public AuditRequestRepository(AssetManagementDbContext context)
            : base(context) { }

        // --- Overrides for generic repository ---

        // Get single AuditRequest with related entities
        public override async Task<AuditRequest?> GetByIdAsync(int auditRequestId)
        {
            return await _dbSet
                         .Include(ar => ar.Asset)
                         .Include(ar => ar.Employee)
                         .Include(ar => ar.Status)
                         .FirstOrDefaultAsync(ar => ar.AuditRequestId == auditRequestId);
        }

        // Optional: Override GetAllAsync to always include relationships
        public override async Task<IEnumerable<AuditRequest>> GetAllAsync()
        {
            return await _dbSet
                         .Include(ar => ar.Asset)
                         .Include(ar => ar.Employee)
                         .Include(ar => ar.Status)
                         .ToListAsync();
        }

        // --- Custom IAuditRequestRepository methods ---

        public async Task<AuditRequest?> GetAuditRequestByIdAsync(int auditRequestId)
        {
            return await GetByIdAsync(auditRequestId);
        }

        public async Task<IEnumerable<AuditRequest>> GetAllAuditRequestsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<AuditRequest> AddAuditRequestAsync(AuditRequest auditRequest)
        {
            return await AddAsync(auditRequest);
        }

        public async Task<AuditRequest> UpdateAuditRequestAsync(AuditRequest auditRequest)
        {
            return await UpdateAsync(auditRequest.AuditRequestId, auditRequest);
        }

        public async Task<bool> DeleteAuditRequestAsync(int auditRequestId)
        {
            var request = await GetByIdAsync(auditRequestId);
            if (request == null) return false;

            await DeleteAsync(auditRequestId);
            return true;
        }

        public async Task<IEnumerable<AuditRequest>> GetAuditRequestsByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                         .Where(ar => ar.EmployeeId == employeeId)
                         .Include(ar => ar.Asset)
                         .Include(ar => ar.Status)
                         .ToListAsync();
        }

        public async Task<IEnumerable<AuditRequest>> GetAuditRequestsByAssetAsync(int assetId)
        {
            return await _dbSet
                         .Where(ar => ar.AssetId == assetId)
                         .Include(ar => ar.Employee)
                         .Include(ar => ar.Status)
                         .ToListAsync();
        }
    }
}


