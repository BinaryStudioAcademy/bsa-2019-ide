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

        [HttpGet("details")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetailsFromToken()
        {
            return Ok(await _userService.GetUserDetailsById(this.GetUserIdFromToken()));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpGet("nickname")]
        public async Task<IEnumerable<UserNicknameDTO>> GetUsersNickByNickname()
        {
            return await _userService.GetUserListByNickNameParts(this.GetUserIdFromToken());
        }
        
        [HttpPut]
        public async Task<ActionResult<UserUpdateDTO>> UpdateUser([FromBody] UserUpdateDTO user)
        {
            var updatedUser = await _userService.UpdateUser(user);
            return Ok(updatedUser);
        }

        [HttpPut("photo")]
        public async Task UpdateAvatar([FromBody] ImageUploadBase64DTO imageUploadBase64DTO)
        {
            var author = this.GetUserIdFromToken();

            await _userService.UpdateUserAvatar(imageUploadBase64DTO, author);
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