using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IAdminLogService
    {
        Task<AdminLog?> GetLogByIdAsync(int logId);
        Task<IEnumerable<AdminLog>> GetAllLogsAsync();
        Task<AdminLog> AddLogAsync(AdminLog log);
        Task<bool> DeleteLogAsync(int logId);
        Task<IEnumerable<AdminLog>> GetLogsByAdminAsync(int adminId);
    }
}
