using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRolesByIdAsync(int id);
        Task<Role> CreateRolesAsync(Role Role);
        Task<bool> UpdateRolesAsync(int id, Role Role);
        Task<bool> DeleteRolesAsync(int id);
    }
}
