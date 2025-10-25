using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        [HttpGet("getAllEmployeesAsync")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await _employeesRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("getEmployeesByIdAsync")]
        public async Task<IActionResult> GetGetEmployeesByIdAsync(int id)
        {
            var employee = await _employeesRepository.GetEmployeesByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost("createEmployeesAsync")]
        public async Task<IActionResult> CreateEmployeesAsync(Employee employee)
        {
            var created = await _employeesRepository.CreateEmployeesAsync(employee);
            return Ok(created);
            //return CreatedAtAction(nameof(GetGetEmployeesByIdAsync), new { id = created.EmployeeId }, created);
        }

        [HttpPut("updateEmployeesAsync")]
        public async Task<IActionResult> UpdateEmployeesAsync(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

            var updated = await _employeesRepository.UpdateEmployeesAsync(employee);
            return Ok(updated);
        }

        [HttpDelete("deleteEmployeesAsync")]
        public async Task<IActionResult> DeleteEmployeesAsync(int id)
        {
            var deleted = await _employeesRepository.DeleteEmployeesAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
