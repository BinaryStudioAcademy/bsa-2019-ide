using AutoMapper;
using IDE.BLL.Services;
using IDE.Common.DTO.User;
using IDE.Common.ModelsDTO.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(UserService userService, AuthService authService, IMapper mapper, ILogger<RegisterController> logger)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegisterDTO user)
        {
            var createdUser = await _userService.CreateUser(user);
            var token = await _authService.GenerateAccessToken(createdUser);
            _logger.LogInformation(LoggingEvents.InsertItem, $"User created {createdUser.Id}");
            var result = new AuthUserDTO
            {
                User = _mapper.Map<UserDTO>(createdUser),
                Token = token
            };

            return CreatedAtAction("GetById", "users", new { id = createdUser.Id }, result);
        }
    }
}