using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountsController : ControllerBase
    {
        private readonly IUserAccountRepository _service;

        public UserAccountsController(IUserAccountRepository service)
        {
            _service = service;
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserAccountCreateDto dto)
        {
            var user = await _service.CreateUserAsync(dto);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(int id, UserAccountUpdateDto dto)
        {
            dto.UserId = id;
            var user = await _service.UpdateUserAsync(dto);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _service.DeleteUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
