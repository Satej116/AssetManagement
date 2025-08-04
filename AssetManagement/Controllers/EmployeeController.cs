using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> Add(EmployeeDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            var added = await _employeeService.AddAsync(employee);
            return Ok(added);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] EmployeeDTO dto)
        {
            if (id != dto.EmployeeId)
                return BadRequest("ID mismatch.");

            // Get the existing employee from DB
            var existing = await _employeeService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var updated = await _employeeService.UpdateAsync(id, existing);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            var dto = _mapper.Map<EmployeeDTO>(employee);
            return Ok(dto);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return Ok(dtoList);
        }

    }
}
