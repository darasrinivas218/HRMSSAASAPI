using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientsController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllClientAsync")]
        public async Task<IActionResult> GetAllClientAsync()
        {
            var clients = await _repository.GetAllClientAsync();
            return Ok(clients);
        }

        [HttpGet("GetClientByIdAsync")]
        public async Task<IActionResult> GetClientByIdAsync(int id)
        {
            var client = await _repository.GetClientByIdAsync(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpPost("createClientAsync")]
        public async Task<IActionResult> CreateClientAsync(Client client)
        {
            var created = await _repository.CreateClientAsync(client);
            return Ok(created);
        }

        [HttpPut("updateClientAsync")]
        public async Task<IActionResult> UpdateClientAsync(int id, Client client)
        {
            if (id != client.ClientId)
                return BadRequest("Client ID mismatch.");

            var updated = await _repository.UpdateClientAsync(client);
            return Ok(updated);
        }

        [HttpDelete("deleteClientAsync")]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            var deleted = await _repository.DeleteClientAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
