using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IDE.API.Extensions;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    //[AllowAnonymous]
    [Authorize]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAllUserProjects()
        {
            //Need to get userId from token
            return Ok(await _projectService.GetAllProjects(this.GetUserIdFromToken()));
        }

        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetCreatedByUserProjects()
        {
            //Need to get userId from token
            return Ok(await _projectService.GetUserProjects(this.GetUserIdFromToken()));
        }

        [HttpGet("assigned")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAssignedToUserProjects()
        {
            //Need to get userId from token
            return Ok(await _projectService.GetAssignedUserProjects(this.GetUserIdFromToken()));
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(ProjectCreateDTO project)
        {
            await _projectService.CreateProject(project);
            return Created("/project", project);
        }
    }
}