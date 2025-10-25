using HRMSSAASAPI.Application.DTOs;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IGenerateInvoiceRepository
    {
        Task<InvoiceSummaryDto> GetInvoiceSummaryAsync(int employeeId, int projectId, DateTime weekStart, DateTime weekEnd);
    }
}
