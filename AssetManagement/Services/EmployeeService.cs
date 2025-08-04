using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTOs;
using AssetManagement.Exceptions;
using AutoMapper;

namespace AssetManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            AssetManagementDbContext context,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _context = context;
            _mapper = mapper;
        }
        public async Task<Employee> AddAsync(Employee entity)
        {
            entity.CreatedAt = DateTime.UtcNow; 
            entity.UpdatedAt = DateTime.UtcNow; 
            return await _employeeRepository.AddAsync(entity);
        }

        public async Task<Employee> UpdateAsync(int id, Employee entity)
        {
            var existing = await _employeeRepository.GetByIdAsync(id);

            if (existing == null)
                throw new EntityNotFoundException(nameof(Employee), id);

            existing.FirstName = entity.FirstName;
            existing.LastName = entity.LastName;
            existing.Email = entity.Email;
            existing.PhoneNumber = entity.PhoneNumber;
            existing.Gender = entity.Gender;
            existing.Address = entity.Address;
            existing.RoleId = entity.RoleId;

            existing.UpdatedAt = DateTime.UtcNow;

            return await _employeeRepository.UpdateAsync(id, existing);
        }

        public async Task<Employee> DeleteAsync(int id)
        {
            var existing = await _employeeRepository.GetByIdAsync(id);
            if (existing == null)
                throw new EntityNotFoundException(nameof(Employee), id);

            return await _employeeRepository.DeleteAsync(id);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {

            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
    }
}
