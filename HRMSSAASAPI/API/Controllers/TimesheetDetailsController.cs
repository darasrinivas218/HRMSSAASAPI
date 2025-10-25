using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetDetailsController : ControllerBase
    {
        private readonly ITimesheetDetailRepository _repository;

        public TimesheetDetailsController(ITimesheetDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllTimesheetDetailsAsync")]
        public async Task<IActionResult> GetAllTimesheetDetailsAsync()
        {
            try
            {
                var details = await _repository.GetAllTimesheetDetailsAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching timesheet details.", Details = ex.Message });
            }
        }

        [HttpGet("master/{timesheetId}")]
        public async Task<IActionResult> GetDetailsByTimesheetIdAsync(int timesheetId)
        {
            try
            {
                var details = await _repository.GetTimesheetDetailsByMasterIdAsync(timesheetId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching records.", Details = ex.Message });
            }
        }

        [HttpGet("getTimesheetDetailByIdAsync")]
        public async Task<IActionResult> GetTimesheetDetailByIdAsync(int id)
        {
            try
            {
                var detail = await _repository.GetTimesheetDetailByIdAsync(id);
                if (detail == null)
                    return NotFound(new { Message = $"TimesheetDetailId {id} not found." });

                return Ok(detail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching record.", Details = ex.Message });
            }
        }

        [HttpPost("createTimesheetDetailAsync")]
        public async Task<IActionResult> CreateTimesheetDetailAsync(TimesheetDetail detail)
        {
            try
            {
                var created = await _repository.CreateTimesheetDetailAsync(detail);
                return CreatedAtAction(nameof(GetTimesheetDetailByIdAsync), new { id = created.TimesheetDetailId }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error creating record.", Details = ex.Message });
            }
        }

        [HttpPut("updateTimesheetDetailAsync")]
        public async Task<IActionResult> UpdateTimesheetDetailAsync(int id, TimesheetDetail detail)
        {
            if (id != detail.TimesheetDetailId)
                return BadRequest(new { Message = "TimesheetDetailId mismatch." });

            try
            {
                var updated = await _repository.UpdateTimesheetDetailAsync(detail);
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

        [HttpDelete("deleteTimesheetDetailAsync")]
        public async Task<IActionResult> DeleteTimesheetDetailAsync(int id)
        {
            try
            {
                var deleted = await _repository.DeleteTimesheetDetailAsync(id);
                if (!deleted)
                    return NotFound(new { Message = $"TimesheetDetailId {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error deleting record.", Details = ex.Message });
            }
        }
    }
}
