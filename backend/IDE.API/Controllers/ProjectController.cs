using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.BLL.Services;
using IDE.Common.DTO.Project;
using IDE.Common.ModelsDTO.DTO.Workspace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.Common.ModelsDTO.DTO.Project;
using System.IO;
using System;
using IDE.DAL.Interfaces;
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
        private readonly IBlobRepository _blobRepo;

        public ProjectController(IProjectService projectService,
                                IProjectMemberSettingsService projectMemberSettings,
                                IProjectStructureService projectStructureService,
                                FileService fileService,
                                IBlobRepository blobRepo)
        {
            _projectStructureService = projectStructureService;
            _projectService = projectService;
            _projectMemberSettings = projectMemberSettings;
            _fileService = fileService;
            _blobRepo = blobRepo;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDescriptionDTO>> GetProjectById(int projectId)
        {
            return Ok(await _projectService.GetProjectById(projectId));
        }

        [HttpGet("author/{projectId}")]
        public async Task<ActionResult<int>> GetAuthorId(int projectId)
        {
            return Ok(await _projectService.GetAuthorId(projectId));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAllUserProjects()
        {
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
            return Ok(await _projectService.GetUserProjects(this.GetUserIdFromToken()));
        }

        [HttpGet("assigned")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAssignedToUserProjects()
        {
            return Ok(await _projectService.GetAssignedUserProjects(this.GetUserIdFromToken()));
        }

        [HttpGet("getFavourite")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetFavouriteUserProjects()
        {
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

            var projectStructureDTO = new ProjectStructureDTO();
            projectStructureDTO.Id = projectId.ToString();
            projectStructureDTO.NestedFiles.Add(new FileStructureDTO()
            {
                Type = 0,
                Details = $"Super important details of file {project.Name}",
                Name = project.Name
            });

            await _projectStructureService.CreateAsync(projectStructureDTO);

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

        [HttpGet("Download/{id}")]
        public async Task<ActionResult> DownloadProject(int id)
        {
            var tempDir = Path.Combine(Directory.GetCurrentDirectory(), "Temp");

            var path = Path.Combine(tempDir, Guid.NewGuid().ToString());

            bool result = await _projectService.MakeProjectZipFile(id, path);
            if (!result) return BadRequest();
            Uri uri;
            try
            {
                uri = await _blobRepo.UploadFileFromPathOnServer(Path.Combine(path, $"project_{id}.zip"));
            }
            catch (FileNotFoundException)
            {

                return NotFound();
            }

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            try
            {

                Stream memStream = await _blobRepo.DownloadFileAsync(uri.ToString(), "DownloadProjectZipContainer");

                return File(memStream, "application/zip", "project.zip");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
