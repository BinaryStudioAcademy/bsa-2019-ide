using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IDE.API.Extensions;
using IDE.BLL.Services;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    //[AllowAnonymous]
    [Authorize]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectMemberSettingsService _projectMemberSettings;
        private readonly IProjectStructureService _projectStructureService;

        public ProjectController(IProjectService projectService, IProjectMemberSettingsService projectMemberSettings,
            IProjectStructureService projectStructureService)
        {
            _projectStructureService = projectStructureService;
            _projectService = projectService;
            _projectMemberSettings = projectMemberSettings;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDescriptionDTO>> GetProjectById(int projectId)
        {
            return Ok(await _projectService.GetProjectById(projectId));
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

        [HttpGet("getFavourite")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetFavouriteUserProjects()
        {
            //Need to get userId from token
            return Ok(await _projectService.GetFavouriteUserProjects(this.GetUserIdFromToken()));
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(ProjectCreateDTO project)
        {
            var author = this.GetUserIdFromToken();
            var id = await _projectService.CreateProject(project, author);
            return Created("/project", id);
        }

        [HttpPut]
        public async Task<ActionResult<ProjectInfoDTO>> UpdateProject([FromBody] ProjectUpdateDTO project)
        {
            var updatedProject = await _projectService.UpdateProject(project);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }

        [HttpPut("favourite")]
        public async Task<ActionResult> SetFavouriteProject([FromBody]int projectId)
        {
            await _projectMemberSettings.SetFavouriteProject(projectId, this.GetUserIdFromToken());
            return NoContent();
        }
    }
}