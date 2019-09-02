using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.BLL.Services;
using IDE.Common.DTO.Project;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.Common.ModelsDTO.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
        private readonly IProjectTemplateService _projectTemplateService;
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
            _projectTemplateService = projectTemplateService;
            _logger = logger;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDescriptionDTO>> GetProjectById(int projectId)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Get project id {projectId}");
            return Ok(await _projectService.GetProjectById(projectId));
        }

        [HttpGet("build/{projectId}")]
        public async Task<ActionResult> BuildProjectById(int projectId)
        {
            await _projectService.BuildProject(projectId);
            return Ok();
        }

        [HttpGet("run/{projectId}/{connectionId}")]
        public async Task<ActionResult> RunProjectById(int projectId, string connectionId)
        {
            await _projectService.RunProject(projectId, connectionId);
            return Ok();
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

        [HttpGet("users/{id}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetByUserProjects(int id)
        {
            return Ok(await _projectService.GetProjectsByUserId(id));
        }

        [HttpGet("usersassigned/{id}")]
        public async Task<ActionResult<IEnumerable<ProjectDescriptionDTO>>> GetAssignedById(int id)
        {
            return Ok(await _projectService.GetAssignedProjectsByUserId(id));
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
            if(project.GithubUrl != null){
                System.Diagnostics.Debug.WriteLine(project.GithubUrl);
                Uri url = new Uri(project.GithubUrl);
                UriBuilder uriBuilder = new UriBuilder(url);
                uriBuilder.Path = Path.Combine(url.AbsolutePath, "archive/master.zip");
                using (HttpClient client = new HttpClient())
                {
                    
                    HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine("*************** success ******************");
                    }
                }
            }
            var projectId = await _projectService.CreateProject(project, author);
            _logger.LogInformation(LoggingEvents.InsertItem, $"Created project {projectId}");

            if (Request.Form.Files.Count > 0)
            {
                var projectStructure  = await _projectStructureService.CreateEmptyAsync(projectId, project.Name);
                var zipFile = Request.Form.Files[0];
                //await _projectStructureService.UnzipProject(projectStructure, zipFile, author, projectId);
                await _projectStructureService.ImportProject(projectStructure.Id, zipFile, projectId.ToString(), author, false, null);
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

        [HttpGet("download/{projectId}")]
        public async Task<ActionResult> DownloadProject(int projectId)
        {
            try
            {
                const string contentType = "application/zip";
                HttpContext.Response.ContentType = contentType;
                var fileByteArray = await _projectStructureService.CreateProjectZipFile(projectId).ConfigureAwait(false);
                var project = await _projectService.GetProjectById(projectId).ConfigureAwait(false);
                return new FileContentResult(fileByteArray ?? new byte[0], contentType)
                {
                    FileDownloadName = project.Name
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, $"File on server not found. ${ex.Message}");
                return NotFound();
            }
        }

        [HttpGet("download/{projectId}/{folderGuid}")]
        public async Task<ActionResult> DownloadProject(int projectId, string folderGuid)
        {
            if (!Guid.TryParse(folderGuid, out _))
                return BadRequest("Folder guid is invalide!");

            try
            {
                const string contentType = "application/zip";
                HttpContext.Response.ContentType = contentType;
                var fileByteArray = await _projectStructureService.CreateProjectZipFile(projectId, folderGuid).ConfigureAwait(false);
                return new FileContentResult(fileByteArray, contentType);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, $"File on server not found. ${ex.Message}");
                return NotFound();
            }
        }
    }
}
