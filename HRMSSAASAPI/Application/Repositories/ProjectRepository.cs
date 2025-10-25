using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using HRMSSAASAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace HRMSSAASAPI.Application.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyDbContext _myDbContext;

        public ProjectRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            try
            {
                return await _myDbContext.Projects.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project list.", ex);
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            try
            {
                return await _myDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching project with ID {id}.", ex);
            }
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            try
            {
                project.CreatedDate = DateTime.Now;
                project.UpdatedDate = DateTime.Now;
                await _myDbContext.Projects.AddAsync(project);
                await _myDbContext.SaveChangesAsync();
                return project;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding project.", ex);
            }
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            try
            {
                var existingProject = await _myDbContext.Projects.FindAsync(project.ProjectId);
                if (existingProject == null)
                    throw new KeyNotFoundException($"Project ID {project.ProjectId} not found.");

                _myDbContext.Entry(existingProject).CurrentValues.SetValues(project);
                existingProject.UpdatedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return existingProject;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating project.", ex);
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            try
            {
                var project = await _myDbContext.Projects.FindAsync(id);
                if (project == null)
                    return false;

                _myDbContext.Projects.Remove(project);
                await _myDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting project.", ex);
            }
        }
    }
}
