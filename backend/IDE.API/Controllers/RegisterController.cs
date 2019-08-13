using AutoMapper;
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
        private readonly IMapper _mapper;

        public RegisterController(UserService userService, AuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegisterDTO user)
        {
            var createdUser = await _userService.CreateUser(user);
            string UserName = createdUser.FirstName + createdUser.LastName + createdUser.NickName;
            var token = await _authService.GenerateAccessToken(createdUser);

            var result = new AuthUserDTO
            {
                User = _mapper.Map<UserDTO>(createdUser),
                Token = token
            };

            return CreatedAtAction("GetById", "users", new { id = createdUser.Id }, result);
        }
    }
}