using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class WeeklyUpdateRepository : IWeeklyUpdateRepository
    {
        private readonly MyDbContext _myDbContext;

        public WeeklyUpdateRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<WeeklyUpdate>> GetAllWeeklyUpdatesAsync()
        {
            try
            {
                return await _myDbContext.WeeklyUpdates.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Weekly Updates: {ex.Message}");
            }
        }

        public async Task<WeeklyUpdate> GetWeeklyUpdateByIdAsync(int id)
        {
            try
            {
                var update = await _myDbContext.WeeklyUpdates.FindAsync(id);
                if (update == null)
                    throw new Exception("Weekly Update not found");

                return update;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Weekly Update by ID: {ex.Message}");
            }
        }

        public async Task<WeeklyUpdate> CreateWeeklyUpdateAsync(WeeklyUpdate weeklyUpdate)
        {
            try
            {
                _myDbContext.WeeklyUpdates.Add(weeklyUpdate);
                await _myDbContext.SaveChangesAsync();
                return weeklyUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating Weekly Update: {ex.Message}");
            }
        }

        public async Task<WeeklyUpdate> UpdateWeeklyUpdateAsync(int id, WeeklyUpdate weeklyUpdate)
        {
            try
            {
                var existingUpdate = await _myDbContext.WeeklyUpdates.FindAsync(id);
                if (existingUpdate == null)
                    throw new Exception("Weekly Update not found");

                existingUpdate.EmployeeId = weeklyUpdate.EmployeeId;
                existingUpdate.ProjectId = weeklyUpdate.ProjectId;
                existingUpdate.WeekStartDate = weeklyUpdate.WeekStartDate;
                existingUpdate.WeekEndDate = weeklyUpdate.WeekEndDate;
                existingUpdate.Summary = weeklyUpdate.Summary;
                existingUpdate.Achievements = weeklyUpdate.Achievements;
                existingUpdate.Challenges = weeklyUpdate.Challenges;
                existingUpdate.PlannedNextWeek = weeklyUpdate.PlannedNextWeek;
                existingUpdate.ReviewedBy = weeklyUpdate.ReviewedBy;
                existingUpdate.ReviewComments = weeklyUpdate.ReviewComments;
                existingUpdate.Status = weeklyUpdate.Status;
                existingUpdate.UpdatedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return existingUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Weekly Update: {ex.Message}");
            }
        }

        public async Task<bool> DeleteWeeklyUpdateAsync(int id)
        {
            try
            {
                var update = await _myDbContext.WeeklyUpdates.FindAsync(id);
                if (update == null)
                    throw new Exception("Weekly Update not found");

                _myDbContext.WeeklyUpdates.Remove(update);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Weekly Update: {ex.Message}");
            }
        }
    }
}
