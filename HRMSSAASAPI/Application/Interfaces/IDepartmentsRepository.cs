using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IDepartmentsRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentsByIdAsync(int id);
        Task<Department> CreateDepartmentsAsync(Department department);
        Task<bool> UpdateDepartmentsAsync(int id, Department department);
        Task<bool> DeleteDepartmentsAsync(int id);
    }
}
