using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        private readonly IBuildService _buildService;

        public BuildsController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<BuildDTO>>> GetBuildsByUserId(int userId)
        {
            return Ok(await _buildService.GetBuildsByUserId(userId));
        }
    }
}