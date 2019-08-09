using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Services;
using IDE.Common.DTO.File;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    // [Authorize] // TODO: use after authorization launch
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;

        public FilesController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<FileDTO>>> GetAllAsync()
        {
            return Ok(await _fileService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileDTO>> GetByIdAsync(string id)
        {
            return Ok(await _fileService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FileDTO fileDto)
        {
            var createdFile = await _fileService.CreateAsync(fileDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdFile.Id }, createdFile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FileDTO fileDto)
        {
            await _fileService.UpdateAsync(fileDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _fileService.DeleteAsync(id);
            return NoContent();
        }
    }
}