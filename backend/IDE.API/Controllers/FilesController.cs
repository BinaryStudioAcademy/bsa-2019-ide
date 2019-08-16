using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.API.Extensions;
using IDE.BLL.Services;
using IDE.Common.DTO.File;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize] // TODO: use after authorization launch
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;

        public FilesController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("forProject/{projectId}")]
        public async Task<ActionResult<ICollection<FileDTO>>> GetAllForProjectAsync(int projectId)
        {
            return Ok(await _fileService.GetAllForProjectAsync(projectId));
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<FileDTO>> GetByIdAsync(string id)
        {
            return Ok(await _fileService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FileCreateDTO fileCreateDTO)
        {
            var authorId = this.GetUserIdFromToken();
            fileCreateDTO.CreatorId = authorId;

            var createdFile = await _fileService.CreateAsync(fileCreateDTO);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdFile.Id }, createdFile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FileUpdateDTO fileUpdateDTO)
        {
            await _fileService.UpdateAsync(fileUpdateDTO);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _fileService.DeleteAsync(id);
            return NoContent();
        }
    }
}