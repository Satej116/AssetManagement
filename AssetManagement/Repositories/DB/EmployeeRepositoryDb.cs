using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories.DB
{
    public class EmployeeRepositoryDb
        : RepositoryDb<int, Employee>, IEmployeeRepository
    {
        public EmployeeRepositoryDb(AssetManagementDbContext context) : base(context)
        {
        }

        // Override generic GetByIdAsync with full include
        public override async Task<Employee?> GetByIdAsync(int employeeId)
        {
            return await _dbSet
                         .Include(e => e.Role)
                         .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        // IEmployeeRepository methods
        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            return await GetByIdAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dbSet
                         .Include(e => e.Role)
                         .ToListAsync();
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
