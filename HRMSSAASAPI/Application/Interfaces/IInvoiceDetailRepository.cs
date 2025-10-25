using HRMSSAASAPI.Domain.Entities;

namespace HRMSSAASAPI.Application.Interfaces
{
    public interface IInvoiceDetailsRepository
    {
        Task<IEnumerable<InvoiceDetail>> GetAllInvoiceDetailsAsync();
        Task<InvoiceDetail> GetInvoiceDetailByIdAsync(int id);
        Task<InvoiceDetail> CreateInvoiceDetailAsync(InvoiceDetail invoiceDetail);
        Task<InvoiceDetail> UpdateInvoiceDetailAsync(int id, InvoiceDetail invoiceDetail);
        Task<bool> DeleteInvoiceDetailAsync(int id);
    }
}
