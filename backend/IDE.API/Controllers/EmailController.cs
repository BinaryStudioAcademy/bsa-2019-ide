using IDE.BLL.Services;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly UserService _userService;
        private readonly ILogger<EmailController> _logger;
        public EmailController(UserService userService, ILogger<EmailController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPut]
        public async Task<ActionResult> VerifyEmail([FromBody]VerificationTokenDTO token)
        {
            await _userService.VerifyEmail(token.Token);
            return NoContent();
        }

        [HttpPut("recover")]
        public async Task<ActionResult> RecoverPassword([FromBody]EmailDTO email)
        {
            await _userService.RecoverPassword(email.Email);
            return NoContent();
        }
    }
}