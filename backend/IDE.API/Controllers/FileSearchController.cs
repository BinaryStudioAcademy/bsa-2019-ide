using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDE.DAL.Entities.Elastic;
using IDE.DAL.Interfaces;
using IDE.DAL.Repositories;
using Microsoft.AspNetCore.Http;
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