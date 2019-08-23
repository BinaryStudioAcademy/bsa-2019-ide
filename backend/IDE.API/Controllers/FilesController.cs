using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.API.Extensions;
using IDE.BLL.Services;
using IDE.Common.DTO.File;
using IDE.Common.ModelsDTO.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize] // TODO: use after authorization launch
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly ILogger<FilesController> _logger;
        public FilesController(FileService fileService, ILogger<FilesController> logger)
        {
            _fileService = fileService;
            _logger = logger;
        }

        [HttpGet("forProject/{projectId}")]
        public async Task<ActionResult<ICollection<FileDTO>>> GetAllForProjectAsync(int projectId)
        {
            _logger.LogInformation(LoggingEvents.ListItems, $"Files for project {projectId}");
            return Ok(await _fileService.GetAllForProjectAsync(projectId));
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<FileDTO>> GetByIdAsync(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Getting file {id}" );
            return Ok(await _fileService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FileCreateDTO fileCreateDTO)
        {
            var authorId = this.GetUserIdFromToken();
            var creatorId = authorId;

            var createdFile = await _fileService.CreateAsync(fileCreateDTO, creatorId);
            _logger.LogInformation(LoggingEvents.InsertItem, $"Created file {createdFile.Id}");
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdFile.Id }, createdFile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FileUpdateDTO fileUpdateDTO)
        {
            _logger.LogInformation(LoggingEvents.UpdateItem, $"Updating file {fileUpdateDTO.Id}");
            var updaterId = this.GetUserIdFromToken();
            await _fileService.UpdateAsync(fileUpdateDTO, updaterId);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            _logger.LogInformation(LoggingEvents.DeleteItem, $"Deleting file {id}");
            await _fileService.DeleteAsync(id);
            return NoContent();
        }
    }
}