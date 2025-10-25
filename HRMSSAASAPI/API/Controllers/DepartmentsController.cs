using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Application.Repositories;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsRepository _depServices;
        public DepartmentsController(IDepartmentsRepository depServices)
        {
            _depServices = depServices;
        }
        [HttpGet("GetAllDepartmentsAsync")]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var departments = await _depServices.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("getDepartmentsByIdAsync")]
        public async Task<IActionResult> GetDepartmentsByIdAsync(int id)
        {
            var department = await _depServices.GetDepartmentsByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost("createDepartmentsAsync")]
        public async Task<IActionResult> CreateDepartmentsAsync([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _depServices.CreateDepartmentsAsync(department);
            return CreatedAtAction(nameof(GetDepartmentsByIdAsync), new { id = created.DepartmentId }, created);
        }

        [HttpPut("updateDepartmentsAsync")]
        public async Task<IActionResult> UpdateDepartmentsAsync(int id, [FromBody] Department department)
        {
            var success = await _depServices.UpdateDepartmentsAsync(id, department);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("deleteDepartmentsAsync")]
        public async Task<IActionResult> DeleteDepartmentsAsync(int id)
        {
            var success = await _depServices.DeleteDepartmentsAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
