using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTOs.Auth;
using System.Security.Cryptography;
using System.Text;

namespace AssetManagement.Services
{
    public class AuthenticationService : IAuthenticate
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationService(
            IRepository<int, Employee> employeeRepository,
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<RegisterResponseDTO> Register(RegisterRequestDTO request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Address = request.Address,
                RoleId = request.RoleId == 2 ? 2 : 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            employee = await _employeeRepository.AddAsync(employee);

            using var hmac = new HMACSHA256();
            var hashKey = Convert.ToBase64String(hmac.Key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            var passwordHash = Convert.ToBase64String(hash);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                HashKey = hashKey,
                EmployeeId = employee.EmployeeId,
                RoleId = employee.RoleId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _userRepository.AddUserAsync(user);

            return new RegisterResponseDTO
            {
                Username = user.Username,
                EmployeeId = employee.EmployeeId,
                RoleName = employee.RoleId == 2 ? "Admin" : "User"
            };
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO request)
        {
            var dbUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (dbUser == null)
                throw new Exception("Invalid username or password.");

            var key = Convert.FromBase64String(dbUser.HashKey);
            using var hmac = new HMACSHA256(key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            var inputHash = Convert.ToBase64String(hash);

            if (inputHash != dbUser.PasswordHash)
                throw new Exception("Invalid username or password.");

            var token = await _tokenService.GenerateToken(new TokenUserDTO
            {
                Username = dbUser.Username,
                Role = dbUser.Role?.RoleName ?? "User"
            });

            return new LoginResponseDTO
            {
                Username = dbUser.Username,
                Token = token,
                Role = dbUser.Role?.RoleName ?? "User"
            };
        }
    }
}
