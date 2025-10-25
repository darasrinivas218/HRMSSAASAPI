using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerBankDetailsController : ControllerBase
    {
        private readonly IEmployerBankDetailRepository _repository;

        public EmployerBankDetailsController(IEmployerBankDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllEmployerBankDetails")]
        public async Task<IActionResult> GetAllEmployerBankDetails()
        {
            try
            {
                var data = await _repository.GetAllEmployerBankDetailsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching employer bank details: {ex.Message}");
            }
        }

        [HttpGet("GetEmployerBankDetailById/{id}")]
        public async Task<IActionResult> GetEmployerBankDetailById(int id)
        {
            try
            {
                var detail = await _repository.GetEmployerBankDetailByIdAsync(id);
                if (detail == null)
                    return NotFound($"Employer bank detail with ID {id} not found.");
                return Ok(detail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching employer bank detail for ID {id}: {ex.Message}");
            }
        }

        [HttpPost("AddEmployerBankDetail")]
        public async Task<IActionResult> AddEmployerBankDetail([FromBody] EmployerBankDetail entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _repository.AddEmployerBankDetailAsync(entity);
                return CreatedAtAction(nameof(GetEmployerBankDetailById), new { id = result.EmployerBankId }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding employer bank detail: {ex.Message}");
            }
        }

        [HttpPut("UpdateEmployerBankDetail/{id}")]
        public async Task<IActionResult> UpdateEmployerBankDetail(int id, [FromBody] EmployerBankDetail entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updated = await _repository.UpdateEmployerBankDetailAsync(id, entity);
                if (updated == null)
                    return NotFound($"Employer bank detail with ID {id} not found.");
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating employer bank detail ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("DeleteEmployerBankDetail/{id}")]
        public async Task<IActionResult> DeleteEmployerBankDetail(int id)
        {
            try
            {
                var success = await _repository.DeleteEmployerBankDetailAsync(id);
                if (!success)
                    return NotFound($"Employer bank detail with ID {id} not found.");

                return Ok($"Employer bank detail with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting employer bank detail ID {id}: {ex.Message}");
            }
        }
    }
}
