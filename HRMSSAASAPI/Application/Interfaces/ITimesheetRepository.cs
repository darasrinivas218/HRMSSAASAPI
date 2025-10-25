using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface ITimesheetRepository
    {
        Task<IEnumerable<TimesheetMaster>> GetAllTimesheetsAsync();
        Task<TimesheetMaster> GetTimesheetByIdAsync(int id);
        Task<TimesheetMaster> CreateTimesheetAsync(TimesheetMaster timesheet);
        Task<TimesheetMaster> UpdateTimesheetAsync(TimesheetMaster timesheet);
        Task<bool> DeleteTimesheetAsync(int id);
    }
}
