using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<Payroll>> GetAllPayrollsAsync();
        Task<Payroll> GetPayrollByIdAsync(int id);
        Task<Payroll> CreatePayrollAsync(Payroll payroll);
        Task<bool> UpdatePayrollAsync(int id, Payroll payroll);
        Task<bool> DeletePayrollAsync(int id);
    }
}
