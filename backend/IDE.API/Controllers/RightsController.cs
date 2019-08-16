using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class RightsController : ControllerBase
    {
        private readonly IRightsService _rightsService;

        public RightsController(IRightsService rightsService)
        {
            _rightsService = rightsService;
        }

        [HttpPut("{projectId}/{access}")]
        public async Task<IActionResult> SetRights(int projectId, UserAccess access)
        {
            await _rightsService.SetRightsToProject(projectId, access, this.GetUserIdFromToken());
            return Ok();
        }

        [HttpGet("{projectId}")]
        public IActionResult GetRights(int projectId)
        {
            return Ok(_rightsService.GetUserRightsForProject(projectId, this.GetUserIdFromToken()));
        }
    }
}