﻿using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.BLL.Services;
using IDE.Common.DTO.Project;
using IDE.Common.ModelsDTO.DTO.Workspace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.Common.ModelsDTO.DTO.User;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    //[AllowAnonymous]
    //[Authorize]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectMemberSettingsService _projectMemberSettings;
        private readonly IProjectStructureService _projectStructureService;
        private readonly FileService _fileService;

        public ProjectController(IProjectService projectService,
                                IProjectMemberSettingsService projectMemberSettings,
                                IProjectStructureService projectStructureService,
                                FileService fileService)
        {
            _projectStructureService = projectStructureService;
            _projectService = projectService;
            _projectMemberSettings = projectMemberSettings;
            _fileService = fileService;
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

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<SearchProjectDTO>>> GetProjectName()
        {
            return Ok(await _projectService.GetProjectsName());
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

        [HttpGet("collaborators/{projectId}")]
        public async Task<ActionResult<IEnumerable<CollaboratorDTO>>> GetListOdProjectCollaborators(int projectId)
        {
            return Ok(await _projectService.GetProjectCollaborators(projectId, this.GetUserIdFromToken()));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectCreateDTO project)
        {
            var author = this.GetUserIdFromToken();
            var projectId = await _projectService.CreateProject(project, author);
            _ = await _projectStructureService.CreateEmptyAsync(projectId.ToString(), project.Name);

            return Created("/project", projectId);
        }

        [HttpPut]
        public async Task<ActionResult<ProjectInfoDTO>> UpdateProject([FromBody] ProjectUpdateDTO project)
        {
            var updatedProject = await _projectService.UpdateProject(project);
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            int userId = this.GetUserIdFromToken();
            await _projectService.DeleteProjectAsync(id, userId);
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