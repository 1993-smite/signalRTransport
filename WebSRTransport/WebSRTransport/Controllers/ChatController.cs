using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebSRTransport.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSRTransport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext) : base()
        {
            _hubContext = hubContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{msg}")]
        public async void Send(string msg)
        {
            await _hubContext.Clients.All.SendAsync("Send", msg); ;
        }

        // POST api/<controller>
        [HttpPost]
        public async void Post([FromBody]string message)
        {
            await _hubContext.Clients.Group(nameof(ChatHub)).SendAsync("Send", message);
        }
    }
}
