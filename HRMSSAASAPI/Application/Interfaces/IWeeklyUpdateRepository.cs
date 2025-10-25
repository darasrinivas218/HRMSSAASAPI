using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IWeeklyUpdateRepository
    {
        Task<IEnumerable<WeeklyUpdate>> GetAllWeeklyUpdatesAsync();
        Task<WeeklyUpdate> GetWeeklyUpdateByIdAsync(int id);
        Task<WeeklyUpdate> CreateWeeklyUpdateAsync(WeeklyUpdate weeklyUpdate);
        Task<WeeklyUpdate> UpdateWeeklyUpdateAsync(int id, WeeklyUpdate weeklyUpdate);
        Task<bool> DeleteWeeklyUpdateAsync(int id);
    }
}
