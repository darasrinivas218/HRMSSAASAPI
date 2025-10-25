using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImmigrationDetailsController : ControllerBase
    {
        private readonly IImmigrationDetailRepository _repository;

        public ImmigrationDetailsController(IImmigrationDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllImmigrationDetails")]
        public async Task<IActionResult> GetAllImmigrationDetails()
        {
            try
            {
                var details = await _repository.GetAllImmigrationDetailsAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving data", Details = ex.Message });
            }
        }

        [HttpGet("getImmigrationDetailById")]
        public async Task<IActionResult> GetImmigrationDetailById(int id)
        {
            try
            {
                var detail = await _repository.GetImmigrationDetailByIdAsync(id);
                return Ok(detail);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving immigration detail", Details = ex.Message });
            }
        }

        [HttpPost("createImmigrationDetail")]
        public async Task<IActionResult> CreateImmigrationDetail([FromBody] ImmigrationDetail immigrationDetail)
        {
            try
            {
                var created = await _repository.CreateImmigrationDetailAsync(immigrationDetail);
                return CreatedAtAction(nameof(GetImmigrationDetailById), new { id = created.ImmigrationId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error creating immigration detail", Details = ex.Message });
            }
        }

        [HttpPut("updateImmigrationDetail")]
        public async Task<IActionResult> UpdateImmigrationDetail(int id, [FromBody] ImmigrationDetail immigrationDetail)
        {
            try
            {
                var updated = await _repository.UpdateImmigrationDetailAsync(id, immigrationDetail);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error updating immigration detail", Details = ex.Message });
            }
        }

        [HttpDelete("deleteImmigrationDetail")]
        public async Task<IActionResult> DeleteImmigrationDetail(int id)
        {
            try
            {
                var result = await _repository.DeleteImmigrationDetailAsync(id);
                return result ? Ok(new { Message = "Immigration detail deleted successfully" }) : NotFound();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error deleting immigration detail", Details = ex.Message });
            }
        }
    }
}
