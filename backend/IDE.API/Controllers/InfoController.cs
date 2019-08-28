using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
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
        private readonly IInfoService _infoService;
        private readonly ILogger<InfoController> _logger;
        public InfoController(IProjectService projectService, IInfoService infoService, ILogger<InfoController> logger)
        {
            _projectService = projectService;
            _logger = logger;
            _infoService = infoService;
        }

        [HttpGet]
        public Task<IEnumerable<LikedProjectInLanguageDTO>> GetMostLikedProjects()
        {
            return _projectService.GetLikedProjects();
        }

        [HttpGet("stats")]
        public async Task<WebSiteInfo> GetStatistics()
        {
            return await _infoService.GetInfo();
        }
    }
}