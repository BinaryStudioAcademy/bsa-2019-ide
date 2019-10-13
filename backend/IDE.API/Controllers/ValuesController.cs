using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET /values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("****************Values page says hello**************");
            return new string[] { "value1", "value2" };
        }

        // GET /values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST /values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
