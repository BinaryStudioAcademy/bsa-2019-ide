using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.BLL.Services;
using IDE.Common.DTO.Project;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IProjectMemberSettingsService _projectMemberSettings;
        private readonly IProjectStructureService _projectStructureService;
        private readonly IProjectTemplateService projectTemplateService;
        private readonly FileService _fileService;
        private readonly IBlobRepository _blobRepo;
        private readonly IProjectTemplateService _projectTemplateService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService,
                                IProjectMemberSettingsService projectMemberSettings,
                                IProjectStructureService projectStructureService,
                                IProjectTemplateService projectTemplateService,
                                FileService fileService,
                                IBlobRepository blobRepo,
                                INotificationService notificationService,
                                ILogger<ProjectController> logger)
        {
            _projectStructureService = projectStructureService;
            _projectService = projectService;
            _projectMemberSettings = projectMemberSettings;
            _fileService = fileService;
            _blobRepo = blobRepo;
            _projectTemplateService = projectTemplateService;
            _notificationService = notificationService;
            _logger = logger;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDescriptionDTO>> GetProjectById(int projectId)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Get project id {projectId}");
            return Ok(await _projectService.GetProjectById(projectId));
        }

        [HttpGet("author/{projectId}")]
        public async Task<ActionResult<int>> GetAuthorId(int projectId)
        {
            return Ok(await _projectService.GetAuthorId(projectId));
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
        public async Task<ActionResult> CreateProject([FromForm] ProjectCreateDTO project)
        {
            var author = this.GetUserIdFromToken();
            var projectId = await _projectService.CreateProject(project, author);
            _logger.LogInformation(LoggingEvents.InsertItem, $"Created project {projectId}");

            if (Request.Form.Files.Count > 0)
            {
                var projectStructure  = await _projectStructureService.CreateEmptyAsync(projectId, project.Name);
                var zipFile = Request.Form.Files[0];
                await _projectStructureService.UnzipProject(projectStructure, zipFile, author, projectId);
            }
            else
            {
                var projectStructureDTO = await _projectTemplateService.GenerateProjectTemplate(project.Name, projectId, author, project.Language);
                await _projectStructureService.CreateAsync(projectStructureDTO);
            }

            return Created("/project", projectId);
        }

        [HttpPut]
        public async Task<ActionResult<ProjectInfoDTO>> UpdateProject([FromBody] ProjectUpdateDTO project)
        {
            var updatedProject = await _projectService.UpdateProject(project);
            _logger.LogInformation(LoggingEvents.UpdateItem, $"Project updated {project.Id}");
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            int userId = this.GetUserIdFromToken();
            await _projectService.DeleteProjectAsync(id, userId);
            _logger.LogInformation(LoggingEvents.DeleteItem, $"Project deleted {id}");
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
            var tempDir = Path.Combine(Directory.GetCurrentDirectory(), "..\\Temp");

            var path = Path.Combine(tempDir, Guid.NewGuid().ToString());

            bool result = await _projectService.CreateProjectZipFile(id, path);
            if (!result) {
                _logger.LogInformation(LoggingEvents.OperationFailed, $"Making project zip failed");
                return BadRequest();
            }
            Uri uri;
            try
            {
                uri = await _blobRepo.UploadFileFromPathOnServer(Path.Combine(path, $"project_{id}.zip"));
            }
            catch (FileNotFoundException)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, $"File on server not found");
                return NotFound();
            }
            finally
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }

            try
            {

                Stream memStream = await _blobRepo.DownloadFileAsync(uri.ToString(), "DownloadProjectZipContainer");

                return File(memStream, "application/zip", "project.zip");
            }
            catch (Exception e)
            {
                _logger.LogWarning(LoggingEvents.OperationFailed, $"Downloading project zip from blob storage failed");
                return BadRequest(e);
            }

        }
    }
}
