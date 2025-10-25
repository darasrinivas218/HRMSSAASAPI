using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly MyDbContext _myDbContext;
        public DepartmentsRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _myDbContext.Departments
                .AsNoTracking()
                .Where(d => d.IsActive)
                .ToListAsync();
        }

        public async Task<Department> GetDepartmentsByIdAsync(int id)
        {
            return await _myDbContext.Departments.FindAsync(id);
        }

        public async Task<Department> CreateDepartmentsAsync(Department department)
        {
            department.CreatedDate = DateTime.Now;
            _myDbContext.Departments.Add(department);
            await _myDbContext.SaveChangesAsync();
            return department;
        }

        public async Task<bool> UpdateDepartmentsAsync(int id, Department department)
        {
            var existing = await _myDbContext.Departments.FindAsync(id);
            if (existing == null) return false;

            existing.DepartmentName = department.DepartmentName;
            existing.DepartmentCode = department.DepartmentCode;
            existing.ManagerId = department.ManagerId;
            existing.IsActive = department.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _myDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDepartmentsAsync(int id)
        {
            var department = await _myDbContext.Departments.FindAsync(id);
            if (department == null) return false;

            _myDbContext.Departments.Remove(department);
            await _myDbContext.SaveChangesAsync();
            return true;
        }
    }
}
