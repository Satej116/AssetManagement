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

        // --- Overrides for generic repository ---

        // Get single Employee with Role
        public override async Task<Employee?> GetByIdAsync(int employeeId)
        {
            return await _dbSet
                         .Include(e => e.Role)
                         .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        // Optional: Override GetAllAsync to include Role
        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbSet
                         .Include(e => e.Role)
                         .ToListAsync();
        }

        // --- IEmployeeRepository Methods (using generic repository) ---

        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await GetByIdAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await AddAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            return await UpdateAsync(employee.EmployeeId, employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await GetByIdAsync(employeeId);
            if (employee == null) return false;

            await DeleteAsync(employeeId);
            return true;
        }
    }
}
