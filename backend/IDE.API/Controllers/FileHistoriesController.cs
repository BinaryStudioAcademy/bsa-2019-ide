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

        [HttpGet("forFile/{fileId:length(24)}")]
        public async Task<ActionResult<ICollection<FileHistoryDTO>>> GetAllAsync(string fileId)
        {
            return Ok(await _fileHistoryService.GetAllForFileAsync(fileId));
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<FileHistoryDTO>> GetByIdAsync(string id)
        {
            return Ok(await _fileHistoryService.GetByIdAsync(id));
        }
    }
}