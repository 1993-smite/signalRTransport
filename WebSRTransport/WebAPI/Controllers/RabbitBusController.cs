using Microsoft.AspNetCore.Mvc;
using RabbitCore.Core;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitBusController : ControllerBase
    {
        readonly IRabbitMqService rabbitMq;

        public RabbitBusController(IRabbitMqService rabbit)
        {
            rabbitMq = rabbit;
        }



        [HttpGet]
        public ActionResult Index()
        {
            return Ok("Test is OK");
        }

        [Route("[action]/{msg}")]
        [HttpPost]
        public ActionResult Send(string msg)
        {
            rabbitMq.SendMessage(msg);

            return Ok($"msg: {msg} SENDED");
        }
    }
}
