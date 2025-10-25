using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly MyDbContext _myDbContext;
        public EmployeesRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _myDbContext.Employees
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeesByIdAsync(int id)
        {
            return await _myDbContext.Employees.FindAsync(id);
        }

        public async Task<Employee> CreateEmployeesAsync(Employee employee)
        {
            _myDbContext.Employees.Add(employee);
            await _myDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeesAsync(Employee employee)
        {
            _myDbContext.Entry(employee).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeesAsync(int id)
        {
            var employee = await _myDbContext.Employees.FindAsync(id);
            if (employee == null)
                return false;

            _myDbContext.Employees.Remove(employee);
            await _myDbContext.SaveChangesAsync();
            return true;
        }
    }
}
