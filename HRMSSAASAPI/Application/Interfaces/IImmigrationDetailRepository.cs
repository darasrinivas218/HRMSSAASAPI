using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IImmigrationDetailRepository
    {
        Task<IEnumerable<ImmigrationDetail>> GetAllImmigrationDetailsAsync();
        Task<ImmigrationDetail> GetImmigrationDetailByIdAsync(int id);
        Task<ImmigrationDetail> CreateImmigrationDetailAsync(ImmigrationDetail immigrationDetail);
        Task<ImmigrationDetail> UpdateImmigrationDetailAsync(int id, ImmigrationDetail immigrationDetail);
        Task<bool> DeleteImmigrationDetailAsync(int id);
    }
}
