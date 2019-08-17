using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace IDE.API.Controllers
{
    [Route("[controller]")]
    //[Authorize]
    [ApiController]
    public class RightsController : ControllerBase
    {
        private readonly IRightsService _rightsService;

        public RightsController(IRightsService rightsService)
        {
            _rightsService = rightsService;
        }

        [HttpPut]
        public async Task<IActionResult> SetRights([FromBody] UpdateUserRightDTO update)
        {
            await _rightsService.SetRightsToProject(update);
            return Ok();
        }

        [HttpGet("{projectId}")]
        public IActionResult GetRights(int projectId)
        {
            return Ok(_rightsService.GetUserRightsForProject(projectId, this.GetUserIdFromToken()));
        }
    }
}