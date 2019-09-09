using IDE.BLL.Services;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.Common.ModelsDTO.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class FileHistoriesController : ControllerBase
    {
        private readonly FileHistoryService _fileHistoryService;
        private readonly FileService _fileService;
        private readonly ILogger<FileHistoriesController> _logger;
        public FileHistoriesController(FileHistoryService fileHistoryService, ILogger<FileHistoriesController> logger, FileService fileService)
        {
            _fileHistoryService = fileHistoryService;
            _logger = logger;
            _fileService = fileService;
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
        
        [HttpGet("histories/{projectId}")]
        public async Task<ActionResult<IDictionary<string, IList<FileHistoryDTO>>>> GetFileHistoriesForProject(int projectId)
        {
            return Ok(await _fileHistoryService.GetLastHistoriesForProject(projectId));
        }
    }
}