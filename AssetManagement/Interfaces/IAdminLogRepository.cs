using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAdminLogRepository : IRepository<int, AdminLog>
    {
        // Custom method
        Task<IEnumerable<AdminLog>> GetLogsByAdminAsync(int adminId);
    }
}
