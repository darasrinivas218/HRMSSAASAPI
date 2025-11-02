using Dapper;
using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace HRMSSAASAPI.Application.Repositories
{
    public class GenerateInvoiceRepository : IGenerateInvoiceRepository
    {
        private readonly MyDbContext _myDbContext;

        public GenerateInvoiceRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<InvoiceSummaryDto> GetInvoiceSummaryAsync(int employeeId, int projectId, DateTime weekStart, DateTime weekEnd)
        {
            try
            {
                var dto = _myDbContext.Set<InvoiceSummaryDto>()
      .FromSqlInterpolated($@"
        EXEC sp_GenerateInvoiceDetails
            @EmployeeId = {employeeId},
            @ProjectId = {projectId},
            @WeekStartDate = {weekStart},
            @WeekEndDate = {weekEnd}")
      .AsNoTracking()
      .AsEnumerable()       // Execute SP first
      .FirstOrDefault();

                var invoiceDetails = new InvoiceDetail
                {
                    InvoiceNumber = dto.InvoiceNumber,          // e.g., "VALI-1001"
                    ClientId = dto.ClientId,
                    EmployeeId = dto.EmployeeId,
                    ProjectId = dto.ProjectId,
                    InvoiceDate = DateTime.Now,               // current invoice date
                    InvoicePeriodFrom = dto.WeekStartDate,
                    InvoicePeriodTo = dto.WeekEndDate,
                    Description = $"Invoice for {dto.EmployeeName}",
                    HoursWorked = dto.TotalHoursWorked,
                    HourlyRate = dto.HourlyRate,
                    SubTotal = dto.SubTotal,
                    Discount = dto.Discount,
                    TaxRate = 0,                          // update if needed
                    TaxAmount = dto.TaxAmount,
                    ShippingHandling = dto.ShippingHandling,
                    TotalAmount = dto.TotalAmount,
                    Remarks = dto.Remarks,
                    PaymentDueDate = DateTime.Now.AddDays(15),   // example due date
                    PaymentStatus = "Pending",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                _myDbContext.InvoiceDetails.Add(invoiceDetails);
                await _myDbContext.SaveChangesAsync();

                //var employeeAddress = await _myDbContext.EmployeeAddress
                //.Where(a => a.EmployeeId == employeeId)
                //.AsNoTracking()
                //.FirstOrDefaultAsync();

                //var clientAddress = await _myDbContext.ClientAddress
                //    .Where(a => a.ClientId == dto.ClientId)
                //    .AsNoTracking()
                //    .FirstOrDefaultAsync();

                //var clientBank = await _myDbContext.ClientBankDetails
                //    .AsNoTracking()
                //    .FirstOrDefaultAsync(b => b.ClientId == dto.ClientId); // adjust if employer is separate

                //dto.EmployeeAddress = employeeAddress;
                //dto.ClientAddress = clientAddress;
                //dto.ClientBankDetails = clientBank;


                return dto;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException("Error fetching invoice summary.", ex);
            }
        }
    }
}

