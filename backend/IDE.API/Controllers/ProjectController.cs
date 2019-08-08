using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProjectController : Controller
    {
        IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("all/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAllUserProjects(int userId)
        {
            return Ok(await _projectService.GetAllProjects(userId));
        }

        [HttpGet("my/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetCreatedByUserProjects(int userId)
        {
            return Ok(await _projectService.GetUserProjects(userId));
        }

        [HttpGet("assigned/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAssignedToUserProjects(int userId)
        {
            return Ok(await _projectService.GetAssignedUserProjects(userId));
        }
    }
}