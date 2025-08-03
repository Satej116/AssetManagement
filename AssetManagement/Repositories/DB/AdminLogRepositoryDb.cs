using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories.DB
{
    public class AdminLogRepositoryDb : RepositoryDb<int, AdminLog>, IAdminLogRepository
    {
        public AdminLogRepositoryDb(AssetManagementDbContext context) : base(context)
        {
        }

        // Override GetByIdAsync for including navigation property (Admin)
        public override async Task<AdminLog?> GetByIdAsync(int logId)
        {
            return await _dbSet
                         .Include(l => l.Admin)
                         .FirstOrDefaultAsync(l => l.LogId == logId);
        }

        // IAdminLogRepository extra methods
        public async Task<IEnumerable<AdminLog>> GetAllLogsAsync()
        {
            return await _dbSet
                         .Include(l => l.Admin)
                         .ToListAsync();
        }

        public async Task<AdminLog> AddLogAsync(AdminLog log)
        {
            return await AddAsync(log);
        }

        public async Task<bool> DeleteLogAsync(int logId)
        {
            var log = await GetByIdAsync(logId);
            if (log == null) return false;

            await DeleteAsync(logId);
            return true;
        }

        public async Task<IEnumerable<AdminLog>> GetLogsByAdminAsync(int adminId)
        {
            return await _dbSet
                         .Where(l => l.AdminId == adminId)
                         .Include(l => l.Admin)
                         .ToListAsync();
        }
    }
}
