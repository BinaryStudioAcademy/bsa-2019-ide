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
    public class FileHistoriesController : ControllerBase
    {
        private readonly FileHistoryService _fileHistoryService;

        public FileHistoriesController(FileHistoryService fileHistoryService)
        {
            _fileHistoryService = fileHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<FileDTO>>> GetAllAsync()
        {
            return Ok(await _fileHistoryService.GetAllAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<FileDTO>> GetByIdAsync(string id)
        {
            return Ok(await _fileHistoryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FileHistoryDTO fileHistoryDto)
        {
            var createdFileHistory = await _fileHistoryService.CreateAsync(fileHistoryDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdFileHistory.Id }, createdFileHistory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FileHistoryDTO fileHistoryDto)
        {
            await _fileHistoryService.UpdateAsync(fileHistoryDto);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _fileHistoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}