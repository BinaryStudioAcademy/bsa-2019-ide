using IDE.API.Extensions;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Git;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class GitController : ControllerBase
    {
        private readonly IGitService _gitService;

        public GitController(IGitService gitService)
        {
            _gitService = gitService;
        }

        //[HttpGet("clone")]
        //public async Task<ActionResult> Clone()
        //{
        //    var userId = this.GetUserIdFromToken();

        //    await _gitService.Clone(userId);

        //    return Ok();
        //}

        [HttpPost("pull")]
        public async Task<ActionResult> PullOrigin([FromBody] GitBranchDTO gitBranchDTO)
        {
            var userId = this.GetUserIdFromToken();

            await _gitService.PullAsync(gitBranchDTO.ProjectId, gitBranchDTO.Branch, userId);

            return Ok();
        }

        [HttpPost("commit")]
        public async Task<ActionResult> Commit([FromBody] GitMessageDTO gitMessageDTO)
        {
            var userId = this.GetUserIdFromToken();

            await _gitService.CreateCommitAsync(gitMessageDTO.ProjectId, gitMessageDTO.Message, userId);

            return Ok();
        }

        [HttpPost("push")]
        public async Task<ActionResult> Push([FromBody] GitBranchDTO gitBranchDTO)
        {
            var userId = this.GetUserIdFromToken();

            await _gitService.PushAsync(gitBranchDTO.ProjectId, gitBranchDTO.Branch, userId);

            return Ok();
        }
    }
}