using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Shared.Interfaces;

namespace IDE.API.Controllers
{
    [Route("rabbit")]
    [AllowAnonymous]
    [ApiController]
    public class TestRabbitMQController : ControllerBase
    {
        private readonly IQueueService _queue;

        public TestRabbitMQController(IQueueService queue)
        {
            _queue = queue;
        }

        //just for test rabbitmq
        [HttpGet]
        public ActionResult<bool> Post()
        {
            return new ActionResult<bool>(_queue.PostValue("send to the client"));

        }
    }
}