using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebSRTransport.Hubs;
using WebSRTransport.Params;

namespace WebSRTransport.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        public static NLog.Logger Logger
            = NLog.Web
            .NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();

        private readonly IHubContext<CommonHub> _hubContext;

        public CommonController(IHubContext<CommonHub> hubContext) : base()
        {
            _hubContext = hubContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Logger.Trace("Common get Test");

            return new string[] { "value1", "value2" };
        }

        // POST api/<controller>
        [HttpPost]
        public async void SendAll([FromBody] string message)
        {
            Logger.Trace($"send all message {message}");
            await _hubContext.Clients.All.SendAsync("Send", message);
        }


        [HttpPost]
        public async void SendGroup([FromBody] SendParamHub param)
        {
            Logger.Trace($"send group {param}");

            await _hubContext.Clients.Group(param.group).SendAsync("Send", param.message);
        }
    }
}
