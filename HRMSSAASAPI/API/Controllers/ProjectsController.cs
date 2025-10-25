using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _repository;

        public ProjectsController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAllProjectsAsync")]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            try
            {
                var result = await _repository.GetAllProjectsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching projects.", Details = ex.Message });
            }
        }

        [HttpGet("getProjectByIdAsync")]
        public async Task<IActionResult> GetProjectByIdAsync(int id)
        {
            try
            {
                var project = await _repository.GetProjectByIdAsync(id);
                if (project == null)
                    return NotFound(new { Message = $"Project ID {id} not found." });

                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching project.", Details = ex.Message });
            }
        }

        [HttpPost("addProjectAsync")]
        public async Task<IActionResult> AddProjectAsync(Project project)
        {
            try
            {
                var created = await _repository.AddProjectAsync(project);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error adding project.", Details = ex.Message });
            }
        }

        [HttpPut("updateProjectAsync")]
        public async Task<IActionResult> UpdateProjectAsync(int id, Project project)
        {
            if (id != project.ProjectId)
                return BadRequest(new { Message = "Project ID mismatch." });

            try
            {
                var updated = await _repository.UpdateProjectAsync(project);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error updating project.", Details = ex.Message });
            }
        }

        [HttpDelete("deleteProjectAsync")]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            try
            {
                var deleted = await _repository.DeleteProjectAsync(id);
                if (!deleted)
                    return NotFound(new { Message = $"Project ID {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error deleting project.", Details = ex.Message });
            }
        }
    }
}
