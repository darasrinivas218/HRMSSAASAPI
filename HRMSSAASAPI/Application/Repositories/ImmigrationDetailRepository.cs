using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class ImmigrationDetailRepository : IImmigrationDetailRepository
    {
        private readonly MyDbContext _myDbContext;

        public ImmigrationDetailRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<ImmigrationDetail>> GetAllImmigrationDetailsAsync()
        {
            try
            {
                return await _myDbContext.ImmigrationDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving immigration details: {ex.Message}");
            }
        }

        public async Task<ImmigrationDetail> GetImmigrationDetailByIdAsync(int id)
        {
            try
            {
                var detail = await _myDbContext.ImmigrationDetails.FindAsync(id);
                if (detail == null)
                    throw new KeyNotFoundException("Immigration detail not found.");

                return detail;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving immigration detail by ID {id}: {ex.Message}");
            }
        }

        public async Task<ImmigrationDetail> CreateImmigrationDetailAsync(ImmigrationDetail immigrationDetail)
        {
            try
            {
                _myDbContext.ImmigrationDetails.Add(immigrationDetail);
                await _myDbContext.SaveChangesAsync();
                return immigrationDetail;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Database error creating immigration detail: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating immigration detail: {ex.Message}");
            }
        }

        public async Task<ImmigrationDetail> UpdateImmigrationDetailAsync(int id, ImmigrationDetail immigrationDetail)
        {
            try
            {
                var existing = await _myDbContext.ImmigrationDetails.FindAsync(id);
                if (existing == null)
                    throw new KeyNotFoundException("Immigration detail not found.");

                existing.EmployeeId = immigrationDetail.EmployeeId;
                existing.VisaType = immigrationDetail.VisaType;
                existing.VisaNumber = immigrationDetail.VisaNumber;
                existing.PassportNumber = immigrationDetail.PassportNumber;
                existing.PassportIssuedCountry = immigrationDetail.PassportIssuedCountry;
                existing.PassportIssueDate = immigrationDetail.PassportIssueDate;
                existing.PassportExpiryDate = immigrationDetail.PassportExpiryDate;
                existing.VisaIssuedDate = immigrationDetail.VisaIssuedDate;
                existing.VisaExpiryDate = immigrationDetail.VisaExpiryDate;
                existing.WorkAuthorizationStatus = immigrationDetail.WorkAuthorizationStatus;
                existing.ImmigrationStatus = immigrationDetail.ImmigrationStatus;
                existing.SponsoringCompany = immigrationDetail.SponsoringCompany;
                existing.LatestI94Number = immigrationDetail.LatestI94Number;
                existing.LatestI94ExpiryDate = immigrationDetail.LatestI94ExpiryDate;
                existing.Comments = immigrationDetail.Comments;
                existing.UpdatedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return existing;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Database update error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating immigration detail: {ex.Message}");
            }
        }

        public async Task<bool> DeleteImmigrationDetailAsync(int id)
        {
            try
            {
                var detail = await _myDbContext.ImmigrationDetails.FindAsync(id);
                if (detail == null)
                    throw new KeyNotFoundException("Immigration detail not found.");

                _myDbContext.ImmigrationDetails.Remove(detail);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Database delete error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting immigration detail: {ex.Message}");
            }
        }
    }
}
