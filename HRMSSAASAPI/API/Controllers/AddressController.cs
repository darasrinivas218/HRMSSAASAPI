using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repo;

        public AddressController(IAddressRepository repo)
        {
            _repo = repo;
        }
        // Get all employee addresses
        [HttpGet("getAllEmployeeAddresses")]
        public async Task<IActionResult> GetAllEmployeeAddresses()
        {
            try
            {
                var addresses = await _repo.GetAllAddressesAsync();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        // Get employee address by ID
        [HttpGet("getEmployeeAddressById/{id}")]
        public async Task<IActionResult> GetEmployeeAddressById(int id)
        {
            try
            {
                var address = await _repo.GetAddressByIdAsync(id);
                if (address == null)
                    return NotFound(new { message = $"Employee address with ID {id} not found." });

                return Ok(address);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        // Get all addresses for a specific employee
        [HttpGet("getEmployeeAddressesByEmployee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeAddressesByEmployee(int employeeId)
        {
            try
            {
                var addresses = await _repo.GetAddressesByEmployeeIdAsync(employeeId);
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        // Create a new employee address
        [HttpPost("createEmployeeAddress")]
        public async Task<IActionResult> CreateEmployeeAddress(EmployeeAddress model)
        {
            try
            {
                var created = await _repo.AddAddressAsync(model);
                return CreatedAtAction(nameof(GetEmployeeAddressById), new { id = created.EmployeeAddressId }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        // Update an existing employee address
        [HttpPut("updateEmployeeAddress/{id}")]
        public async Task<IActionResult> UpdateEmployeeAddress(int id, EmployeeAddress model)
        {
            if (id != model.EmployeeAddressId)
                return BadRequest(new { message = "Employee address ID mismatch." });

            try
            {
                var updated = await _repo.UpdateAddressAsync(model);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        // Delete an employee address
        [HttpDelete("deleteEmployeeAddress/{id}")]
        public async Task<IActionResult> DeleteEmployeeAddress(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAddressAsync(id);
                return deleted
                    ? NoContent()
                    : NotFound(new { message = $"Employee address ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        [HttpGet("getAllClientAddresses")]
        public async Task<IActionResult> GetAllClientAddresses()
        {
            try
            {
                var addresses = await _repo.GetAllClientAddressesAsync();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        [HttpGet("getClientAddressById/{id}")]
        public async Task<IActionResult> GetClientAddressById(int id)
        {
            try
            {
                var address = await _repo.GetClientAddressByIdAsync(id);
                if (address == null)
                    return NotFound(new { message = $"Client address with ID {id} not found." });

                return Ok(address);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        [HttpGet("getClientAddressesByClient/{clientId}")]
        public async Task<IActionResult> GetClientAddressesByClient(int clientId)
        {
            try
            {
                var addresses = await _repo.GetClientAddressesByClientIdAsync(clientId);
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        [HttpPost("createClientAddress")]
        public async Task<IActionResult> CreateClientAddress(ClientAddress model)
        {
            try
            {
                var created = await _repo.AddClientAddressAsync(model);
                return CreatedAtAction(nameof(GetClientAddressById), new { id = created.ClientAddressId }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        [HttpPut("updateClientAddress/{id}")]
        public async Task<IActionResult> UpdateClientAddress(int id, ClientAddress model)
        {
            if (id != model.ClientAddressId)
                return BadRequest(new { message = "Client address ID mismatch." });

            try
            {
                var updated = await _repo.UpdateClientAddressAsync(model);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }

        [HttpDelete("deleteClientAddress/{id}")]
        public async Task<IActionResult> DeleteClientAddress(int id)
        {
            try
            {
                var deleted = await _repo.DeleteClientAddressAsync(id);
                return deleted
                    ? NoContent()
                    : NotFound(new { message = $"Client address ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }
    }
}
