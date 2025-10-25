using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IEmployeeBankDetailRepository
    {
        Task<IEnumerable<EmployeeBankDetail>> GetAllBankDetailsAsync();
        Task<EmployeeBankDetail?> GetBankDetailByIdAsync(int id);
        Task<EmployeeBankDetail> AddNewBankDetailAsync(EmployeeBankDetail entity);
        Task<EmployeeBankDetail?> UpdateBankDetailAsync(int id, EmployeeBankDetail entity);
        Task<bool> DeleteBankDetailAsync(int id);
    }
}
