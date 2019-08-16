using IDE.BLL.Services;
using IDE.Common.ModelsDTO.DTO.Workspace;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateAsync([FromBody] ProjectStructureDTO projectStructureDTO)
        {
            var createdProjectStructure = await _projectStructureService.CreateAsync(projectStructureDTO);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProjectStructure.Id }, createdProjectStructure);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProjectStructureDTO projectStructureDTO)
        {
            await _projectStructureService.UpdateAsync(projectStructureDTO);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectStructureDTO>> GetByIdAsync(string id)
        {
            return Ok(await _projectStructureService.GetByIdAsync(id));
        }
    }
}