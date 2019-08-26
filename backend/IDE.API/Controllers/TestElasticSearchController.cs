using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.DAL.Entities.Elastic;
using IDE.DAL.Interfaces;
using IDE.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        private FileSearchRepository _fileSearchRepository;

        public TestElasticSearchController(ISearchRepository<TestDocument> serchRepository, FileSearchRepository fileSearchRepository)
        {
            _searchRepository = serchRepository;
            _fileSearchRepository = fileSearchRepository;
        }

        [HttpGet("addone")]
        public async Task AddOneToIndex()
        {
            await _searchRepository.IndexAsync(new TestDocument { Id = "1", Brand = "Samsung" });
        }

        [HttpGet("addmany")]
        public async Task AddManyToIndex()
        {
            await _searchRepository.IndexManyAsync(
                new List<TestDocument>
                {
                    new TestDocument { Id = "2", Brand = "OnePlus lorem" },
                    new TestDocument { Id = "3", Brand = "lorem Sony" },
                    new TestDocument { Id = "4", Brand = "Xialoremomi" },
                    new TestDocument { Id = "5", Brand = "App lorem le" },
                    new TestDocument { Id = "6", Brand = "Nokia" },
                    new TestDocument { Id = "7", Brand = "Motorola" },
                    new TestDocument { Id = "8", Brand = "Huawei" },
                    new TestDocument { Id = "9", Brand = "Lenovo" },
                    new TestDocument { Id = "10", Brand = "Meizu" },
                    new TestDocument { Id = "11", Brand = "Meizu" },
                    new TestDocument { Id = "12", Brand = "Meizu123" },
                    new TestDocument { Id = "13", Brand = "Mei123" },
                    new TestDocument { Id = "13", Brand = "Meizmi" }
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
            return await _fileSearchRepository.CreateIndex();
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
            await _searchRepository.UpdateAsync(new TestDocument { Id = "1", Brand = "Samsung Samsung Samsung" });
        }

        [HttpGet("fileSearch")]
        public async Task<ActionResult> FileSearch(string query)
        {
            return Ok(await _fileSearchRepository.SearchAsync(query));
        }
    }
}