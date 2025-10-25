using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class EmployeeBankDetailRepository : IEmployeeBankDetailRepository
    {
        private readonly MyDbContext _myDbContext;

        public EmployeeBankDetailRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<EmployeeBankDetail>> GetAllBankDetailsAsync()
        {
            try
            {
                return await _myDbContext.EmployeeBankDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while fetching bank details: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeBankDetail?> GetBankDetailByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.EmployeeBankDetails.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while fetching bank detail for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeBankDetail> AddNewBankDetailAsync(EmployeeBankDetail entity)
        {
            try
            {
                _myDbContext.EmployeeBankDetails.Add(entity);
                await _myDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding new bank detail: " + ex.Message, ex);
            }
        }

        public async Task<EmployeeBankDetail?> UpdateBankDetailAsync(int id, EmployeeBankDetail entity)
        {
            try
            {
                var existing = await _myDbContext.EmployeeBankDetails.FindAsync(id);
                if (existing == null)
                    return null;

                existing.EmployeeId = entity.EmployeeId;
                existing.BankName = entity.BankName;
                existing.AccountHolderName = entity.AccountHolderName;
                existing.AccountNumber = entity.AccountNumber;
                existing.RoutingNumber = entity.RoutingNumber;
                existing.AccountType = entity.AccountType;
                existing.IsPrimary = entity.IsPrimary;
                existing.IsVerified = entity.IsVerified;
                existing.UpdatedDate = DateTime.UtcNow;

                await _myDbContext.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating bank detail for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteBankDetailAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.EmployeeBankDetails.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.EmployeeBankDetails.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting bank detail for ID {id}: {ex.Message}", ex);
            }
        }
    }
}
