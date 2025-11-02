using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class InvoiceDetailsRepository : IInvoiceDetailsRepository
    {
        private readonly MyDbContext _myDbContext;

        public InvoiceDetailsRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetAllInvoiceDetailsAsync()
        {
            try
            {
                return await _myDbContext.InvoiceDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving invoice details: {ex.Message}");
            }
        }

        public async Task<InvoiceDetail> GetInvoiceDetailByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.InvoiceDetails.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving invoice detail with ID {id}: {ex.Message}");
            }
        }

        public async Task<InvoiceDetail> CreateInvoiceDetailAsync(InvoiceDetail invoiceDetail)
        {
            try
            {
                _myDbContext.InvoiceDetails.Add(invoiceDetail);
                await _myDbContext.SaveChangesAsync();
                return invoiceDetail;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating invoice detail: {ex.Message}");
            }
        }

        public async Task<InvoiceDetail> UpdateInvoiceDetailAsync(int id, InvoiceDetail invoiceDetail)
        {
            try
            {
                var existingInvoice = await _myDbContext.InvoiceDetails.FindAsync(id);
                if (existingInvoice == null) return null;

                existingInvoice.InvoiceNumber = invoiceDetail.InvoiceNumber;
                existingInvoice.ClientId = invoiceDetail.ClientId;
                existingInvoice.EmployeeId = invoiceDetail.EmployeeId;
                existingInvoice.ProjectId = invoiceDetail.ProjectId;                
                existingInvoice.InvoiceDate = invoiceDetail.InvoiceDate;
                existingInvoice.InvoicePeriodFrom = invoiceDetail.InvoicePeriodFrom;
                existingInvoice.InvoicePeriodTo = invoiceDetail.InvoicePeriodTo;
                existingInvoice.Description = invoiceDetail.Description;
                existingInvoice.HoursWorked = invoiceDetail.HoursWorked;
                existingInvoice.HourlyRate = invoiceDetail.HourlyRate;
                existingInvoice.SubTotal = invoiceDetail.SubTotal;
                existingInvoice.Discount = invoiceDetail.Discount;
                existingInvoice.TaxRate = invoiceDetail.TaxRate;
                existingInvoice.TaxAmount = invoiceDetail.TaxAmount;
                existingInvoice.ShippingHandling = invoiceDetail.ShippingHandling;
                existingInvoice.TotalAmount = invoiceDetail.TotalAmount;
                existingInvoice.Remarks = invoiceDetail.Remarks;
                existingInvoice.PaymentDueDate = invoiceDetail.PaymentDueDate;
                existingInvoice.PaymentStatus = invoiceDetail.PaymentStatus;
                existingInvoice.UpdatedDate = DateTime.Now;

                _myDbContext.InvoiceDetails.Update(existingInvoice);
                await _myDbContext.SaveChangesAsync();
                return existingInvoice;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating invoice detail with ID {id}: {ex.Message}");
            }
        }

        public async Task<bool> DeleteInvoiceDetailAsync(int id)
        {
            try
            {
                var invoice = await _myDbContext.InvoiceDetails.FindAsync(id);
                if (invoice == null) return false;

                _myDbContext.InvoiceDetails.Remove(invoice);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting invoice detail with ID {id}: {ex.Message}");
            }
        }
    }
}
