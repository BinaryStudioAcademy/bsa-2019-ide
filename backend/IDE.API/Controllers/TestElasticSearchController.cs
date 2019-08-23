using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.DAL.Entities.Elastic;
using IDE.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("elastic")]
    [ApiController]
    public class TestElasticSearchController : ControllerBase
    {
        //This controller is needed just to check if elastic works
        //Elastic repositories will be used in other services and i didn`t do a separate service
        // For resting
        // specific entry in the index - http://localhost:9200/test/_doc/1 

        private ISearchRepository<TestDocument> _searchRepository;
        private readonly ILogger<TestElasticSearchController> _logger;
        public TestElasticSearchController(ISearchRepository<TestDocument> serchRepository, ILogger<TestElasticSearchController> logger)
        {
            _searchRepository = serchRepository;
            _logger = logger;
        }

        [HttpGet("addone")]
        public async Task AddOneToIndex()
        {
            await _searchRepository.IndexAsync(new TestDocument("1", "Samsung"));
        }

        [HttpGet("addmany")]
        public async Task AddManyToIndex()
        {
            await _searchRepository.IndexManyAsync(
                new List<TestDocument>
                {
                    new TestDocument("2", "OnePlus"),
                    new TestDocument("3", "Sony"),
                    new TestDocument("4", "Xiaomi"),
                    new TestDocument("5", "Apple"),
                    new TestDocument("6", "Nokia"),
                    new TestDocument("7", "Motorola"),
                    new TestDocument("8", "Huawei"),
                    new TestDocument("9", "Lenovo"),
                    new TestDocument("10", "Meizu"),
                });
        }

        [HttpGet("s")]
        public async Task<ActionResult> Search(string query)
        {
             return Ok(await _searchRepository.SearchAsync(query));
        }

        [HttpGet("a")]
        public async Task<ActionResult> AutoComplete(string query)
        {
            return Ok(await _searchRepository.AutoCompleteAsync(query));
        }


        [HttpGet("index")]
        public async Task<bool> CreateIndex()
        {
            return await _searchRepository.CreateIndex();
        }

        [HttpGet("indexdel")]
        public async Task<bool> DelIndex()
        {
            return await _searchRepository.DeleteIndex();
        }

        [HttpGet("delete/{id}")]
        public async Task DelDocument(string id)
        {
            await _searchRepository.DeleteAsync(id);
        }

        [HttpGet("update")]
        public async Task UpdateDoc()
        {
            await _searchRepository.UpdateAsync(new TestDocument("1", "Samsung Samsung Samsung"));
        }
    }
}