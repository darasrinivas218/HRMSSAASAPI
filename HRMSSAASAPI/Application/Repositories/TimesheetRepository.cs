using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly MyDbContext _myDbContext;

        public TimesheetRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<TimesheetMaster>> GetAllTimesheetsAsync()
        {
            try
            {
                return await _myDbContext.TimesheetMaster.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching timesheets.", ex);
            }
        }

        public async Task<TimesheetMaster> GetTimesheetByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.TimesheetMaster.FirstOrDefaultAsync(t => t.TimesheetId == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching timesheet with ID {id}.", ex);
            }
        }

        public async Task<TimesheetMaster> CreateTimesheetAsync(TimesheetMaster timesheet)
        {
            try
            {
                timesheet.CreatedDate = DateTime.Now;
                timesheet.UpdatedDate = DateTime.Now;

                await _myDbContext.TimesheetMaster.AddAsync(timesheet);
                await _myDbContext.SaveChangesAsync();

                return timesheet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating timesheet record.", ex);
            }
        }

        public async Task<TimesheetMaster> UpdateTimesheetAsync(TimesheetMaster timesheet)
        {
            try
            {
                var existing = await _myDbContext.TimesheetMaster.FindAsync(timesheet.TimesheetId);
                if (existing == null)
                    throw new KeyNotFoundException($"TimesheetId {timesheet.TimesheetId} not found.");

                _myDbContext.Entry(existing).CurrentValues.SetValues(timesheet);
                existing.UpdatedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating timesheet record.", ex);
            }
        }

        public async Task<bool> DeleteTimesheetAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.TimesheetMaster.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.TimesheetMaster.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting timesheet record.", ex);
            }
        }
    }
}
