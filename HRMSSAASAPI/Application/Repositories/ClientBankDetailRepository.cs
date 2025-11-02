using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class ClientBankDetailRepository : IClientBankDetailRepository
    {
        private readonly MyDbContext _myDbContext;

        public ClientBankDetailRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<ClientBankDetail>> GetAllClientBankDetailsAsync()
        {
            try
            {
                return await _myDbContext.ClientBankDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching employer bank details: {ex.Message}", ex);
            }
        }

        public async Task<ClientBankDetail?> GetClientBankDetailByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.ClientBankDetails.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching employer bank detail for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<ClientBankDetail> AddClientBankDetailAsync(ClientBankDetail entity)
        {
            try
            {
                _myDbContext.ClientBankDetails.Add(entity);
                await _myDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding employer bank detail: {ex.Message}", ex);
            }
        }

        public async Task<ClientBankDetail?> UpdateClientBankDetailAsync(int id, ClientBankDetail entity)
        {
            try
            {
                var existing = await _myDbContext.ClientBankDetails.FindAsync(id);
                if (existing == null)
                    return null;
                existing.ClientId = entity.ClientId;
                existing.ClientBankName = entity.ClientBankName;
                existing.ClientBankAccountHolderName = entity.ClientBankAccountHolderName;
                existing.ClientBankAccountNumber = entity.ClientBankAccountNumber;
                existing.ClientBankRoutingNumber = entity.ClientBankRoutingNumber;
                existing.ClientBankAccountType = entity.ClientBankAccountType;
                existing.ClientBankIsPrimary = entity.ClientBankIsPrimary;
                existing.ClientBankIsVerified = entity.ClientBankIsVerified;
                existing.ClientBankUpdatedDate = DateTime.UtcNow;

                await _myDbContext.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating employer bank detail ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteClientBankDetailAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.ClientBankDetails.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.ClientBankDetails.Remove(existing);
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
