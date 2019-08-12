using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    //[Authorize]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDescriptionDTO>> GetProjectById(int projectId)
        {
            return Ok(await _projectService.GetProjectById(projectId));
        }

        [HttpGet("all/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAllUserProjects(int userId)
        {
            //Need to get userId from token
            return Ok(await _projectService.GetAllProjects(3));
        }

        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetCreatedByUserProjects()
        {
            //Need to get userId from token
            return Ok(await _projectService.GetUserProjects(3));
        }

        [HttpGet("assigned")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAssignedToUserProjects()
        {
            //Need to get userId from token
            return Ok(await _projectService.GetAssignedUserProjects(3));
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(ProjectCreateDTO project)
        {
            var id = await _projectService.CreateProject(project);
            return Created("/project", id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditProject(ProjectEditDTO project, int id)
        {
            await _projectService.UpdateProject(project, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}