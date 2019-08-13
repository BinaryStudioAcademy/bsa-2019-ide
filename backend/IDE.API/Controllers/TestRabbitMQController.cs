using IDE.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return new ActionResult<bool>(_queue.SendMessage("send to the client"));

        }
    }
}