using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>> GetAllUserAsync();
        Task<UserAccount> GetUserByIdAsync(int id);
        Task<UserAccount> CreateUserAsync(UserAccountCreateDto dto);
        Task<UserAccount> UpdateUserAsync(UserAccountUpdateDto dto);
        Task<bool> DeleteUserAsync(int id);
    }
}
