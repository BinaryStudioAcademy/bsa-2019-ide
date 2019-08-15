using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public InfoController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpGet]
        public Task<IEnumerable<LikedProjectInLanguageDTO>> GetMostLikedProjects()
        {
            return _projectService.GetLikedProjects();
        }
    }
}