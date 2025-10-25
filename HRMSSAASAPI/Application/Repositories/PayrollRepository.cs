using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly MyDbContext _myDbContext;

        public PayrollRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<Payroll>> GetAllPayrollsAsync()
        {
            return await _myDbContext.Payroll.ToListAsync();
        }

        public async Task<Payroll> GetPayrollByIdAsync(int id)
        {
            return await _myDbContext.Payroll.FindAsync(id);
        }

        public async Task<Payroll> CreatePayrollAsync(Payroll payroll)
        {
            _myDbContext.Payroll.Add(payroll);
            await _myDbContext.SaveChangesAsync();
            return payroll;
        }

        public async Task<bool> UpdatePayrollAsync(int id, Payroll payroll)
        {
            if (id != payroll.PayrollId) return false;

            _myDbContext.Entry(payroll).State = EntityState.Modified;
            payroll.UpdatedDate = DateTime.UtcNow;

            try
            {
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PayrollExists(id)) return false;
                throw;
            }
        }

        public async Task<bool> DeletePayrollAsync(int id)
        {
            var payroll = await _myDbContext.Payroll.FindAsync(id);
            if (payroll == null) return false;

            _myDbContext.Payroll.Remove(payroll);
            await _myDbContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> PayrollExists(int id)
        {
            return await _myDbContext.Payroll.AnyAsync(e => e.PayrollId == id);
        }
    }
}
