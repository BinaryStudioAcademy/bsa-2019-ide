using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileSearchController : ControllerBase
    {
        private FileSearchRepository _fileSearchRepository;
        private readonly ILogger<FileSearchController> _logger;
        private readonly IProjectService _projectService;
        public FileSearchController(FileSearchRepository fileSearchRepository, ILogger<FileSearchController> logger, IProjectService projectService)
        {
            _fileSearchRepository = fileSearchRepository;
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult> FileSearch(string query, int projectId)
        {
            return Ok(await _fileSearchRepository.SearchAsync(query, projectId));
        }

        [HttpGet("globalsearch")]
        public async Task<ActionResult<List<FileSearchResultDTO>>> FileSearchGlobal(string query)
        {
            var userId = this.GetUserIdFromToken();
            ICollection<SearchProjectDTO> allowedProjects = await _projectService.GetProjectsName(userId);
            var result = await _fileSearchRepository.SearchAsyncGlobal(query, allowedProjects);
            return Ok(result);
        }
    }
}