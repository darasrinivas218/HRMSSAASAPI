using HRMSSAASAPI.Application.DTOs;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task<bool> LogoutAsync(string token);
    }
}
