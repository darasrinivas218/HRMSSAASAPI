using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRolesRepository _rolesServices;
        public RolesController(IRolesRepository rolesServices)
        {
            _rolesServices = rolesServices;
        }
        [HttpGet("GetAllRolesAsync")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var Roles = await _rolesServices.GetAllRolesAsync();
            return Ok(Roles);
        }

        [HttpGet("getRolesByIdAsync")]
        public async Task<IActionResult> GetRolesByIdAsync(int id)
        {
            var Role = await _rolesServices.GetRolesByIdAsync(id);
            if (Role == null)
                return NotFound();
            return Ok(Role);
        }

        [HttpPost("createRolesAsync")]
        public async Task<IActionResult> CreateRolesAsync([FromBody] Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _rolesServices.CreateRolesAsync(role);
            return CreatedAtAction(nameof(GetRolesByIdAsync), new { id = created.RoleId }, created);
        }

        [HttpPut("updateRolesAsync")]
        public async Task<IActionResult> UpdateRolesAsync(int id, [FromBody] Role role)
        {
            var success = await _rolesServices.UpdateRolesAsync(id, role);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("deleteRolesAsync")]
        public async Task<IActionResult> DeleteRolesAsync(int id)
        {
            var success = await _rolesServices.DeleteRolesAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
