using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<InfoController> _logger;
        public InfoController(IProjectService projectService, ILogger<InfoController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        public Task<IEnumerable<LikedProjectInLanguageDTO>> GetMostLikedProjects()
        {
            return _projectService.GetLikedProjects();
        }
    }
}