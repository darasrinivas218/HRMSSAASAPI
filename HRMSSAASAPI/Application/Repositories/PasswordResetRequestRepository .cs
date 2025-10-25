using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class PasswordResetRequestRepository : IPasswordResetRequestRepository
    {
        private readonly MyDbContext _myDbContext;

        public PasswordResetRequestRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<PasswordResetRequest>> GetAllPasswordResetRequestsAsync()
        {
            try
            {
                return await _myDbContext.PasswordResetRequests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving password reset requests.", ex);
            }
        }

        public async Task<PasswordResetRequest> GetPasswordResetRequestByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.PasswordResetRequests.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving record with ID {id}.", ex);
            }
        }

        public async Task<PasswordResetRequest> CreatePasswordResetRequestAsync(PasswordResetRequest request)
        {
            try
            {
                _myDbContext.PasswordResetRequests.Add(request);
                await _myDbContext.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating password reset request.", ex);
            }
        }

        public async Task<PasswordResetRequest> UpdatePasswordResetRequestAsync(PasswordResetRequest request)
        {
            try
            {
                _myDbContext.Entry(request).State = EntityState.Modified;
                await _myDbContext.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating record with ID {request.RequestId}.", ex);
            }
        }

        public async Task<bool> DeletePasswordResetRequestAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.PasswordResetRequests.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.PasswordResetRequests.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting record with ID {id}.", ex);
            }
        }
    }
}
