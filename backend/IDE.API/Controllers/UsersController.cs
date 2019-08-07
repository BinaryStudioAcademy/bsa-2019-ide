using IDE.API.Extensions;
using System.Threading.Tasks;
using IDE.BLL.Services;
using IDE.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("fromToken")]
        public async Task<ActionResult<UserDTO>> GetUserFromToken()
        {
            return Ok(await _userService.GetUserById(this.GetUserIdFromToken()));
        }
    }
}