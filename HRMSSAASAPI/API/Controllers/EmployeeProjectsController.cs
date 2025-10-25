using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectsController : ControllerBase
    {
        private readonly IEmployeeProjectRepository _repository;

        public EmployeeProjectsController(IEmployeeProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllEmployeeProjectsAsync")]
        public async Task<IActionResult> GetAllEmployeeProjectsAsync()
        {
            try
            {
                var result = await _repository.GetAllEmployeeProjectsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching employee-projects.", Details = ex.Message });
            }
        }

        [HttpGet("getEmployeeProjectByIdAsync")]
        public async Task<IActionResult> GetEmployeeProjectByIdAsync(int id)
        {
            try
            {
                var data = await _repository.GetEmployeeProjectByIdAsync(id);
                if (data == null)
                    return NotFound(new { Message = $"EmployeeProjectId {id} not found." });

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching record.", Details = ex.Message });
            }
        }

        [HttpPost("createEmployeeProjectAsync")]
        public async Task<IActionResult> CreateEmployeeProjectAsync(EmployeeProject employeeProject)
        {
            try
            {
                var created = await _repository.CreateEmployeeProjectAsync(employeeProject);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error creating record.", Details = ex.Message });
            }
        }

        [HttpPut("updateEmployeeProjectAsync")]
        public async Task<IActionResult> UpdateEmployeeProjectAsync(int id, EmployeeProject employeeProject)
        {
            if (id != employeeProject.EmployeeProjectId)
                return BadRequest(new { Message = "EmployeeProjectId mismatch." });

            try
            {
                var updated = await _repository.UpdateEmployeeProjectAsync(employeeProject);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error updating record.", Details = ex.Message });
            }
        }

        [HttpDelete("deleteEmployeeProjectAsync")]
        public async Task<IActionResult> DeleteEmployeeProjectAsync(int id)
        {
            try
            {
                var deleted = await _repository.DeleteEmployeeProjectAsync(id);
                if (!deleted)
                    return NotFound(new { Message = $"EmployeeProjectId {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error deleting record.", Details = ex.Message });
            }
        }
    }
}
