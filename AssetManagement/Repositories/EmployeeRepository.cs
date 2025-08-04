using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories.DB;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories
{
    public class EmployeeRepository : RepositoryDb<int, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AssetManagementDbContext context)
            : base(context) { }

        public override async Task<Employee?> GetByIdAsync(int employeeId)
        {
            return await _dbSet
                .Where(e => e.EmployeeId == employeeId)
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbSet
                .Include(e => e.Role)
                .ToListAsync();

        }
    }
}
