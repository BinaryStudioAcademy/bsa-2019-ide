using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDE.BLL.Services;
using IDE.Common.ModelsDTO.DTO.Workspace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectStructureController : ControllerBase
    {
        private readonly ProjectStructureService _projectStructureService;

        public ProjectStructureController(ProjectStructureService projectStructureService)
        {
            _projectStructureService = projectStructureService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProjectStructureDTO fileCreateDTO)
        {
            var createdFile = await _projectStructureService.CreateAsync(fileCreateDTO);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdFile.Id }, createdFile);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectStructureDTO>> GetByIdAsync(string id)
        {
            return Ok(await _projectStructureService.GetByIdAsync(id));
        }
    }
}