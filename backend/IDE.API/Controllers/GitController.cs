using IDE.API.Extensions;
using IDE.BLL.Interfaces;
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

        [HttpGet("pull/{projectId}/{branch}")]
        public async Task<ActionResult> PullOrigin(string projectId, string branch)
        {
            var userId = this.GetUserIdFromToken();

            await _gitService.PullAsync(projectId, branch, userId);

            return Ok();
        }

        [HttpGet("commit/{projectId}/{message}")]
        public async Task<ActionResult> Commit(string projectId, string message)
        {
            var userId = this.GetUserIdFromToken();

            await _gitService.CreateCommitAsync(projectId, message, userId);

            return Ok();
        }

        [HttpGet("push/{projectId}/{branch}")]
        public async Task<ActionResult> Push(string projectId, string branch)
        {
            var userId = this.GetUserIdFromToken();

            await _gitService.PushAsync(projectId, branch, userId);

            return Ok();
        }
    }
}