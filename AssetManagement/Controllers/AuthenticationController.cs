using AssetManagement.Interfaces;
using AssetManagement.Models.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;

        public AuthenticationController(IAuthenticate authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            try
            {
                var result = await _authenticateService.Register(request);

                if (result != null)
                {
                    return Ok(new
                    {
                        message = "Registration successful.",
                        username = result.Username,
                        employeeId = result.EmployeeId,
                        roleName = result.RoleName
                    });
                }

                return BadRequest(new { message = "Registration failed." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                var response = await _authenticateService.Login(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
