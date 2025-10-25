using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IEmployeeProjectRepository
    {
        Task<IEnumerable<EmployeeProject>> GetAllEmployeeProjectsAsync();
        Task<EmployeeProject> GetEmployeeProjectByIdAsync(int id);
        Task<EmployeeProject> CreateEmployeeProjectAsync(EmployeeProject employeeProject);
        Task<EmployeeProject> UpdateEmployeeProjectAsync(EmployeeProject employeeProject);
        Task<bool> DeleteEmployeeProjectAsync(int id);
    }
}
