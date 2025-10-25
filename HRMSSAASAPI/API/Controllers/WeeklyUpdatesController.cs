using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeeklyUpdatesController : ControllerBase
    {
        private readonly IWeeklyUpdateRepository _weeklyUpdateRepository;

        public WeeklyUpdatesController(IWeeklyUpdateRepository weeklyUpdateRepository)
        {
            _weeklyUpdateRepository = weeklyUpdateRepository;
        }

        [HttpGet("getAllWeeklyUpdates")]
        public async Task<IActionResult> GetAllWeeklyUpdates()
        {
            try
            {
                var updates = await _weeklyUpdateRepository.GetAllWeeklyUpdatesAsync();
                return Ok(updates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("getWeeklyUpdateById")]
        public async Task<IActionResult> GetWeeklyUpdateById(int id)
        {
            try
            {
                var update = await _weeklyUpdateRepository.GetWeeklyUpdateByIdAsync(id);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }

        [HttpPost("createWeeklyUpdate")]
        public async Task<IActionResult> CreateWeeklyUpdate([FromBody] WeeklyUpdate weeklyUpdate)
        {
            try
            {
                var createdUpdate = await _weeklyUpdateRepository.CreateWeeklyUpdateAsync(weeklyUpdate);
                return CreatedAtAction(nameof(GetWeeklyUpdateById), new { id = createdUpdate.UpdateId }, createdUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("updateWeeklyUpdate")]
        public async Task<IActionResult> UpdateWeeklyUpdate(int id, [FromBody] WeeklyUpdate weeklyUpdate)
        {
            try
            {
                var updated = await _weeklyUpdateRepository.UpdateWeeklyUpdateAsync(id, weeklyUpdate);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteWeeklyUpdate")]
        public async Task<IActionResult> DeleteWeeklyUpdate(int id)
        {
            try
            {
                var result = await _weeklyUpdateRepository.DeleteWeeklyUpdateAsync(id);
                return result ? Ok("Weekly Update deleted successfully") : NotFound("Not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
