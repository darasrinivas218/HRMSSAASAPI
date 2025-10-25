using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class EmployerBankDetailRepository : IEmployerBankDetailRepository
    {
        private readonly MyDbContext _myDbContext;

        public EmployerBankDetailRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<EmployerBankDetail>> GetAllEmployerBankDetailsAsync()
        {
            try
            {
                return await _myDbContext.EmployerBankDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching employer bank details: {ex.Message}", ex);
            }
        }

        public async Task<EmployerBankDetail?> GetEmployerBankDetailByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.EmployerBankDetails.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching employer bank detail for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<EmployerBankDetail> AddEmployerBankDetailAsync(EmployerBankDetail entity)
        {
            try
            {
                _myDbContext.EmployerBankDetails.Add(entity);
                await _myDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding employer bank detail: {ex.Message}", ex);
            }
        }

        public async Task<EmployerBankDetail?> UpdateEmployerBankDetailAsync(int id, EmployerBankDetail entity)
        {
            try
            {
                var existing = await _myDbContext.EmployerBankDetails.FindAsync(id);
                if (existing == null)
                    return null;

                existing.EmployerId = entity.EmployerId;
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
                throw new Exception($"Error updating employer bank detail ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteEmployerBankDetailAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.EmployerBankDetails.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.EmployerBankDetails.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting employer bank detail ID {id}: {ex.Message}", ex);
            }
        }
    }
}
