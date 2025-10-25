using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface ITimesheetDetailRepository
    {
        Task<IEnumerable<TimesheetDetail>> GetAllTimesheetDetailsAsync();
        Task<IEnumerable<TimesheetDetail>> GetTimesheetDetailsByMasterIdAsync(int timesheetId);
        Task<TimesheetDetail> GetTimesheetDetailByIdAsync(int id);
        Task<TimesheetDetail> CreateTimesheetDetailAsync(TimesheetDetail detail);
        Task<TimesheetDetail> UpdateTimesheetDetailAsync(TimesheetDetail detail);
        Task<bool> DeleteTimesheetDetailAsync(int id);
    }
}
