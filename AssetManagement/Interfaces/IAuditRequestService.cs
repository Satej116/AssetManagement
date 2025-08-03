using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAuditRequestService
    {
        Task<AuditRequest?> GetAuditRequestByIdAsync(int auditRequestId);
        Task<IEnumerable<AuditRequest>> GetAllAuditRequestsAsync();
        Task<AuditRequest> AddAuditRequestAsync(AuditRequest auditRequest);
        Task<AuditRequest> UpdateAuditRequestAsync(AuditRequest auditRequest);
        Task<bool> DeleteAuditRequestAsync(int auditRequestId);
        Task<IEnumerable<AuditRequest>> GetAuditRequestsByEmployeeAsync(int employeeId);
        Task<IEnumerable<AuditRequest>> GetAuditRequestsByAssetAsync(int assetId);
    }
}
