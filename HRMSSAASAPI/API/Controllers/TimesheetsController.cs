using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly ITimesheetRepository _repository;

        public TimesheetsController(ITimesheetRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllTimesheetsAsync")]
        public async Task<IActionResult> GetAllTimesheetsAsync()
        {
            try
            {
                var timesheets = await _repository.GetAllTimesheetsAsync();
                return Ok(timesheets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching timesheets.", Details = ex.Message });
            }
        }

        [HttpGet("getTimesheetByIdAsync")]
        public async Task<IActionResult> GetTimesheetByIdAsync(int id)
        {
            try
            {
                var timesheet = await _repository.GetTimesheetByIdAsync(id);
                if (timesheet == null)
                    return NotFound(new { Message = $"TimesheetId {id} not found." });

                return Ok(timesheet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching record.", Details = ex.Message });
            }
        }

        [HttpPost("createTimesheetAsync")]
        public async Task<IActionResult> CreateTimesheetAsync(TimesheetMaster timesheet)
        {
            try
            {
                var created = await _repository.CreateTimesheetAsync(timesheet);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error creating timesheet.", Details = ex.Message });
            }
        }

        [HttpPut("updateTimesheetAsync")]
        public async Task<IActionResult> UpdateTimesheetAsync(int id, TimesheetMaster timesheet)
        {
            if (id != timesheet.TimesheetId)
                return BadRequest(new { Message = "TimesheetId mismatch." });

            try
            {
                var updated = await _repository.UpdateTimesheetAsync(timesheet);
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

        [HttpDelete("deleteTimesheetAsync")]
        public async Task<IActionResult> DeleteTimesheetAsync(int id)
        {
            try
            {
                var deleted = await _repository.DeleteTimesheetAsync(id);
                if (!deleted)
                    return NotFound(new { Message = $"TimesheetId {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error deleting record.", Details = ex.Message });
            }
        }
    }
}
