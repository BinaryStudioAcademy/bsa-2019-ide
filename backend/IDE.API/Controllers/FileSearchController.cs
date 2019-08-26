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
        private ISearchRepository<TestDocument> _searchRepository;
        private FileSearchRepository _fileSearchRepository;
        private readonly ILogger<TestElasticSearchController> _logger;

        public FileSearchController(ISearchRepository<TestDocument> serchRepository, FileSearchRepository fileSearchRepository, ILogger<TestElasticSearchController> logger)
        {
            _searchRepository = serchRepository;
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