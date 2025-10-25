using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class TimesheetDetailRepository : ITimesheetDetailRepository
    {
        private readonly MyDbContext _myDbContext;

        public TimesheetDetailRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<TimesheetDetail>> GetAllTimesheetDetailsAsync()
        {
            try
            {
                return await _myDbContext.TimesheetDetails.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching timesheet details.", ex);
            }
        }

        public async Task<IEnumerable<TimesheetDetail>> GetTimesheetDetailsByMasterIdAsync(int timesheetId)
        {
            try
            {
                return await _myDbContext.TimesheetDetails
                    .Where(t => t.TimesheetId == timesheetId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching details for TimesheetId {timesheetId}.", ex);
            }
        }

        public async Task<TimesheetDetail> GetTimesheetDetailByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.TimesheetDetails
                    .FirstOrDefaultAsync(t => t.TimesheetDetailId == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching TimesheetDetail with ID {id}.", ex);
            }
        }

        public async Task<TimesheetDetail> CreateTimesheetDetailAsync(TimesheetDetail detail)
        {
            try
            {
                detail.CreatedDate = DateTime.Now;
                detail.UpdatedDate = DateTime.Now;

                await _myDbContext.TimesheetDetails.AddAsync(detail);
                await _myDbContext.SaveChangesAsync();
                return detail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating TimesheetDetail record.", ex);
            }
        }

        public async Task<TimesheetDetail> UpdateTimesheetDetailAsync(TimesheetDetail detail)
        {
            try
            {
                var existing = await _myDbContext.TimesheetDetails.FindAsync(detail.TimesheetDetailId);
                if (existing == null)
                    throw new KeyNotFoundException($"TimesheetDetailId {detail.TimesheetDetailId} not found.");

                _myDbContext.Entry(existing).CurrentValues.SetValues(detail);
                existing.UpdatedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating TimesheetDetail record.", ex);
            }
        }

        public async Task<bool> DeleteTimesheetDetailAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.TimesheetDetails.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.TimesheetDetails.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting TimesheetDetail record.", ex);
            }
        }
    }
}
