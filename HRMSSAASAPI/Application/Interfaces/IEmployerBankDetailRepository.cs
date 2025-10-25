using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IEmployerBankDetailRepository
    {
        Task<IEnumerable<EmployerBankDetail>> GetAllEmployerBankDetailsAsync();
        Task<EmployerBankDetail?> GetEmployerBankDetailByIdAsync(int id);
        Task<EmployerBankDetail> AddEmployerBankDetailAsync(EmployerBankDetail entity);
        Task<EmployerBankDetail?> UpdateEmployerBankDetailAsync(int id, EmployerBankDetail entity);
        Task<bool> DeleteEmployerBankDetailAsync(int id);
    }
}
