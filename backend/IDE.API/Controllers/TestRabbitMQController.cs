using IDE.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("rabbit")]
    [AllowAnonymous]
    [ApiController]
    public class TestRabbitMQController : ControllerBase
    {
        private readonly IQueueService _queue;
        private readonly ILogger<TestRabbitMQController> _logger;
        public TestRabbitMQController(IQueueService queue, ILogger<TestRabbitMQController> logger)
        {
            _queue = queue;
            _logger = logger;
        }

        //just for test rabbitmq
        [HttpGet]
        public ActionResult<bool> Post()
        {
            return new ActionResult<bool>(_queue.SendMessage("send to the client"));

        }
    }
}