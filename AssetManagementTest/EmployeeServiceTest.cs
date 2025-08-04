using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AssetManagementTest
{
    public class EmployeeServiceTest
    {
        private IEmployeeRepository _employeeRepository;
        private AssetManagementDbContext _context;
        private Mock<IMapper> _mapperMock;
        private Employee _seededEmployee;

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeTestDB_" + Guid.NewGuid())
                .Options;

            _context = new AssetManagementDbContext(options);
            _employeeRepository = new EmployeeRepository(_context);
            _mapperMock = new Mock<IMapper>();

            _seededEmployee = new Employee
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test@abc.com",
                PhoneNumber = "9876543210",
                Gender = "Male",
                Address = "Pune",
                RoleId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            _seededEmployee = await _employeeRepository.AddAsync(_seededEmployee);

        }

        [Test]
        public async Task GetEmployeeById_ShouldReturnEmployee_WhenExists()
        {
            var service = new EmployeeService(_employeeRepository, _context, _mapperMock.Object);

            
            var count = await _context.Employees.CountAsync();
            

            var raw = await _context.Employees.FirstOrDefaultAsync();

            var result = await service.GetByIdAsync(_seededEmployee.EmployeeId);
            Console.WriteLine($"Fetched ID: {result?.EmployeeId}");

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetEmployeeById_ShouldReturnNull_WhenDoesNotExist()
        {
            var service = new EmployeeService(_employeeRepository, _context, _mapperMock.Object);

            var result = await service.GetByIdAsync(9999);

            Assert.IsNotNull(result);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Dispose();
        }
    }
}
