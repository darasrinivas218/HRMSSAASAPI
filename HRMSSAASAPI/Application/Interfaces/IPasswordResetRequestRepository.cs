using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IPasswordResetRequestRepository
    {
        Task<IEnumerable<PasswordResetRequest>> GetAllPasswordResetRequestsAsync();
        Task<PasswordResetRequest> GetPasswordResetRequestByIdAsync(int id);
        Task<PasswordResetRequest> CreatePasswordResetRequestAsync(PasswordResetRequest request);
        Task<PasswordResetRequest> UpdatePasswordResetRequestAsync(PasswordResetRequest request);
        Task<bool> DeletePasswordResetRequestAsync(int id);
    }
}
