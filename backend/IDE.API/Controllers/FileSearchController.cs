using System.Threading.Tasks;
using IDE.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileSearchController : ControllerBase
    {
        private FileSearchRepository _fileSearchRepository;
        private readonly ILogger<FileSearchController> _logger;

        public FileSearchController(FileSearchRepository fileSearchRepository, ILogger<FileSearchController> logger)
        {
            _fileSearchRepository = fileSearchRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> FileSearch(string query, int projectId)
        {
            return Ok(await _fileSearchRepository.SearchAsync(query, projectId));
        }
    }
}