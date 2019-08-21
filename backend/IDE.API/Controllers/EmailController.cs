using IDE.BLL.Services;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly UserService _userService;

        public EmailController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<ActionResult> VerifyEmail([FromBody]VerificationTokenDTO token)
        {
            await _userService.VerifyEmail(token.Token);
            return NoContent();
        }
    }
}