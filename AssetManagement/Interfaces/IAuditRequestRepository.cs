using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAuditRequestRepository : IRepository<int, AuditRequest>
    {
        Task<IEnumerable<AuditRequest>> GetAuditRequestsByEmployeeAsync(int employeeId);
        Task<IEnumerable<AuditRequest>> GetAuditRequestsByAssetAsync(int assetId);
    }
}
