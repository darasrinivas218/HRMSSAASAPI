using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly MyDbContext _myDbContext;

        public EmployeeProjectRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<EmployeeProject>> GetAllEmployeeProjectsAsync()
        {
            try
            {
                return await _myDbContext.EmployeeProjects.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching employee-project mappings.", ex);
            }
        }

        public async Task<EmployeeProject> GetEmployeeProjectByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.EmployeeProjects.FirstOrDefaultAsync(ep => ep.EmployeeProjectId == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching employee-project mapping with ID {id}.", ex);
            }
        }

        public async Task<EmployeeProject> CreateEmployeeProjectAsync(EmployeeProject employeeProject)
        {
            try
            {
                employeeProject.CreatedDate = DateTime.Now;
                employeeProject.UpdatedDate = DateTime.Now;

                await _myDbContext.EmployeeProjects.AddAsync(employeeProject);
                await _myDbContext.SaveChangesAsync();

                return employeeProject;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating employee-project mapping.", ex);
            }
        }

        public async Task<EmployeeProject> UpdateEmployeeProjectAsync(EmployeeProject employeeProject)
        {
            try
            {
                var existing = await _myDbContext.EmployeeProjects.FindAsync(employeeProject.EmployeeProjectId);
                if (existing == null)
                    throw new KeyNotFoundException($"EmployeeProjectId {employeeProject.EmployeeProjectId} not found.");

                _myDbContext.Entry(existing).CurrentValues.SetValues(employeeProject);
                existing.UpdatedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee-project mapping.", ex);
            }
        }

        public async Task<bool> DeleteEmployeeProjectAsync(int id)
        {
            try
            {
                var existing = await _myDbContext.EmployeeProjects.FindAsync(id);
                if (existing == null)
                    return false;

                _myDbContext.EmployeeProjects.Remove(existing);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting employee-project mapping.", ex);
            }
        }
    }
}
