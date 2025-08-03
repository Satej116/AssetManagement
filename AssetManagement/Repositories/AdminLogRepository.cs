using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class AdminLogRepository : RepositoryDb<int, AdminLog>, IAdminLogRepository
    {
        public AdminLogRepository(AssetManagementDbContext context) : base(context) { }

        // Extra method: Logs for a specific Admin
        public async Task<IEnumerable<AdminLog>> GetLogsByAdminAsync(int adminId)
        {
            return await _dbSet
                         .Where(l => l.AdminId == adminId)
                         .Include(l => l.Admin)
                         .ToListAsync();
        }

        // Override to include navigation
        public override async Task<AdminLog?> GetByIdAsync(int logId)
        {
            return await _dbSet
                         .Include(l => l.Admin)
                         .FirstOrDefaultAsync(l => l.AdminLogId == logId);
        }

        // Override to include navigation
        public override async Task<IEnumerable<AdminLog>> GetAllAsync()
        {
            return await _dbSet
                         .Include(l => l.Admin)
                         .ToListAsync();
        }
    }
}
