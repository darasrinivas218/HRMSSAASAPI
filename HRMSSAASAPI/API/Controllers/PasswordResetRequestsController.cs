using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetRequestsController : ControllerBase
    {
        private readonly IPasswordResetRequestRepository _repository;

        public PasswordResetRequestsController(IPasswordResetRequestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _repository.GetAllPasswordResetRequestsAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _repository.GetPasswordResetRequestByIdAsync(id);
                if (item == null) return NotFound();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PasswordResetRequest model)
        {
            if (model == null) return BadRequest("Invalid data.");
            try
            {
                var created = await _repository.CreatePasswordResetRequestAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = created.RequestId }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PasswordResetRequest model)
        {
            if (id != model.RequestId) return BadRequest("ID mismatch.");
            try
            {
                var updated = await _repository.UpdatePasswordResetRequestAsync(model);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _repository.DeletePasswordResetRequestAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
