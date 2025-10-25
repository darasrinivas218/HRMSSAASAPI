using Dapper;
using HRMSSAASAPI.Application.DTOs;
using HRMSSAASAPI.Application.Interfaces;
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
                var invoice = _myDbContext.Set<InvoiceSummaryDto>()
      .FromSqlInterpolated($@"
        EXEC sp_GenerateInvoiceDetails
            @EmployeeId = {employeeId},
            @ProjectId = {projectId},
            @WeekStartDate = {weekStart},
            @WeekEndDate = {weekEnd}")
      .AsNoTracking()
      .AsEnumerable()       // Execute SP first
      .FirstOrDefault();

                return invoice;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException("Error fetching invoice summary.", ex);
            }
        }
    }
}

