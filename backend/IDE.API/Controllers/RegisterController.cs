using IDE.BLL.Services;
using IDE.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public RegisterController(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegisterDTO user)
        {
            var createdUser = await _userService.CreateUser(user);
            string UserName = createdUser.FirstName + createdUser.LastName + createdUser.NickName;
            var token = await _authService.GenerateAccessToken(createdUser.Id, UserName, createdUser.Email);

            var result = new AuthUserDTO
            {
                User = createdUser,
                Token = token
            };

            return CreatedAtAction("GetById", "users", new { id = createdUser.Id }, result);
        }
    }
}