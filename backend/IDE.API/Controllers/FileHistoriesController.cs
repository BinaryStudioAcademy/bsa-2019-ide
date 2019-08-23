using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Services;
using IDE.Common.DTO.File;
using IDE.Common.ModelsDTO.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    // [Authorize] // TODO: use after authorization launch
    [ApiController]
    public class FileHistoriesController : ControllerBase
    {
        private readonly FileHistoryService _fileHistoryService;
        private readonly ILogger<FileHistoriesController> _logger;
        public FileHistoriesController(FileHistoryService fileHistoryService, ILogger<FileHistoriesController> logger)
        {
            _fileHistoryService = fileHistoryService;
            _logger = logger;
        }

        [HttpGet("forFile/{fileId:length(24)}")]
        public async Task<ActionResult<ICollection<FileHistoryDTO>>> GetAllAsync(string fileId)
        {
            _logger.LogInformation(LoggingEvents.ListItems, $"Files history {fileId}");
            return Ok(await _fileHistoryService.GetAllForFileAsync(fileId));
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<FileHistoryDTO>> GetByIdAsync(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"Get history file id {id}");
            return Ok(await _fileHistoryService.GetByIdAsync(id));
        }
    }
}