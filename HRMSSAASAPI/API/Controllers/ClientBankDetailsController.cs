using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientBankDetailsController : ControllerBase
    {
        private readonly IClientBankDetailRepository _repository;

        public ClientBankDetailsController(IClientBankDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllClientBankDetails")]
        public async Task<IActionResult> GetAllClientBankDetails()
        {
            try
            {
                var data = await _repository.GetAllClientBankDetailsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching employer bank details: {ex.Message}");
            }
        }

        [HttpGet("getClientBankDetailById/{id}")]
        public async Task<IActionResult> GetClientBankDetailById(int id)
        {
            try
            {
                var detail = await _repository.GetClientBankDetailByIdAsync(id);
                if (detail == null)
                    return NotFound($"Employer bank detail with ID {id} not found.");
                return Ok(detail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching employer bank detail for ID {id}: {ex.Message}");
            }
        }

        [HttpPost("addClientBankDetail")]
        public async Task<IActionResult> AddClientBankDetail([FromBody] ClientBankDetail entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _repository.AddClientBankDetailAsync(entity);
                return CreatedAtAction(nameof(GetClientBankDetailById), new { id = result.ClientBankId }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding employer bank detail: {ex.Message}");
            }
        }

        [HttpPut("updateClientBankDetail/{id}")]
        public async Task<IActionResult> UpdateClientBankDetail(int id, [FromBody] ClientBankDetail entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updated = await _repository.UpdateClientBankDetailAsync(id, entity);
                if (updated == null)
                    return NotFound($"Employer bank detail with ID {id} not found.");
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating employer bank detail ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("deleteClientBankDetail/{id}")]
        public async Task<IActionResult> DeleteClientBankDetail(int id)
        {
            try
            {
                var success = await _repository.DeleteClientBankDetailAsync(id);
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
