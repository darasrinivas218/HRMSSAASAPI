using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeesByIdAsync(int id);
        Task<Employee> CreateEmployeesAsync(Employee employee);
        Task<Employee> UpdateEmployeesAsync(Employee employee);
        Task<bool> DeleteEmployeesAsync(int id);
    }
}
