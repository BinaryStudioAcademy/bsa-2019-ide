using IDE.API.Extensions;
using IDE.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IDE.Common.ModelsDTO.DTO.Authentification;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly AuthService _authService;

        public TokenController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<ActionResult<AccessTokenDTO>> Refresh([FromBody] RefreshTokenDTO dto)
        {
            return Ok(await _authService.RefreshToken(dto));
        }

        [HttpPost("revoke")]
        public async Task<ActionResult> RevokeRevokeRefreshToken(RevokeRefreshTokenDTO dto)
        {
            var userId = this.GetUserIdFromToken();
            await _authService.RevokeRefreshToken(dto.RefreshToken, userId);
            return Ok();
        }
    }
}
