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

        [HttpGet("all/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAllUserProjects(int userId)
        {
            //Need to get userId from token
            return Ok(await _projectService.GetAllProjects(userId));
        }

        [HttpGet("my/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetCreatedByUserProjects(int userId)
        {
            //Need to get userId from token
            return Ok(await _projectService.GetUserProjects(userId));
        }

        [HttpGet("assigned/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAssignedToUserProjects(int userId)
        {
            //Need to get userId from token
            return Ok(await _projectService.GetAssignedUserProjects(userId));
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(ProjectCreateDTO project)
        {
            await _projectService.CreateProject(project);
            return Created("/project", project);
        }
    }
}