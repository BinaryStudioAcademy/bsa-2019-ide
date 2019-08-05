using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDE.BLL.Services;
using IDE.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : Controller
    {
        private AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUserDTO>> Login(UserLoginDTO dto)
        {
            return Ok(await _authService.Authorize(dto));
        }
    }
}