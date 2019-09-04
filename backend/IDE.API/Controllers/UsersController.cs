using IDE.API.Extensions;
using System.Threading.Tasks;
using IDE.BLL.Services;
using IDE.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using IDE.Common.ModelsDTO.DTO.User;
using System.Collections.Generic;
using IDE.Common.DTO.Image;
using Microsoft.Extensions.Logging;
using IDE.Common.ModelsDTO.Enums;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("fromToken")]
        public async Task<ActionResult<UserDTO>> GetUserFromToken()
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Get user from token");
            return Ok(await _userService.GetUserById(this.GetUserIdFromToken()));
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser(UserDetailsDTO userDTO)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Update user");
            return Ok(await _userService.Update(userDTO));
        }

        [HttpPut("profile")]
        public async Task<ActionResult<UserDTO>> UpdateProfile(UserUpdateDTO userDTO)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Update user");
            return Ok(await _userService.UpdateUser(userDTO));
        }

        [HttpGet("details")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetailsFromToken()
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Get user details from token");
            return Ok(await _userService.GetUserDetailsById(this.GetUserIdFromToken()));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Get user by id {id}");
            return Ok(await _userService.GetUserDetailsById(id));
        }

        [HttpGet("nickname")]
        public async Task<IEnumerable<UserNicknameDTO>> GetUsersNickByNickname()
        {
            return await _userService.GetUserListByNickNameParts(this.GetUserIdFromToken());
        }


        [HttpPut("photo")]
        public async Task UpdateAvatar([FromBody] ImageUploadBase64DTO imageUploadBase64DTO)
        {
            var author = this.GetUserIdFromToken();

            await _userService.UpdateUserAvatar(imageUploadBase64DTO, author);
        }

        [HttpPut("password")]
        public async Task UpdatePassword([FromBody]UserChangePasswordDTO userChangePasswordDTO)
        {
            var userId = this.GetUserIdFromToken();

            await _userService.ChangePassword(userChangePasswordDTO, userId);
        }

        [HttpDelete("photo/del")]
        public async Task<ActionResult> DeleteAvatar()
        {
            var author = this.GetUserIdFromToken();

            await _userService.DeleteAvatar(author);
            return NoContent();
        }
    }
}