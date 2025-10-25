using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBankDetailsController : ControllerBase
    {
        private readonly IEmployeeBankDetailRepository _repository;

        public EmployeeBankDetailsController(IEmployeeBankDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllEmployeeBankDetails")]
        public async Task<IActionResult> GetAllEmployeeBankDetails()
        {
            try
            {
                var data = await _repository.GetAllBankDetailsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while fetching bank details: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeeBankDetailById/{id}")]
        public async Task<IActionResult> GetEmployeeBankDetailById(int id)
        {
            try
            {
                var detail = await _repository.GetBankDetailByIdAsync(id);
                if (detail == null)
                    return NotFound($"Bank detail with ID {id} not found.");

                return Ok(detail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while fetching bank detail ID {id}: {ex.Message}");
            }
        }

        [HttpPost("AddEmployeeBankDetail")]
        public async Task<IActionResult> AddEmployeeBankDetail([FromBody] EmployeeBankDetail entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _repository.AddNewBankDetailAsync(entity);
                return CreatedAtAction(nameof(GetEmployeeBankDetailById), new { id = result.EmployeeBankId }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while adding bank detail: {ex.Message}");
            }
        }

        [HttpPut("UpdateEmployeeBankDetail/{id}")]
        public async Task<IActionResult> UpdateEmployeeBankDetail(int id, [FromBody] EmployeeBankDetail entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updated = await _repository.UpdateBankDetailAsync(id, entity);
                if (updated == null)
                    return NotFound($"Bank detail with ID {id} not found.");

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while updating bank detail ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("DeleteEmployeeBankDetail/{id}")]
        public async Task<IActionResult> DeleteEmployeeBankDetail(int id)
        {
            try
            {
                var success = await _repository.DeleteBankDetailAsync(id);
                if (!success)
                    return NotFound($"Bank detail with ID {id} not found.");

                return Ok($"Bank detail with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while deleting bank detail ID {id}: {ex.Message}");
            }
        }
    }
}
