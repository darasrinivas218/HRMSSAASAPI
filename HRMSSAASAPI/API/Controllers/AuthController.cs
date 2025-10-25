using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            try
            {
                var result = await _auth.LoginAsync(model);
                return Ok(result);
            }
            catch
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDto model)
        {
            var result = await _auth.LogoutAsync(model.Token);
            if (result) return Ok(new { message = "Logged out successfully" });
            return BadRequest(new { message = "Logout failed" });
        }
    }
}
