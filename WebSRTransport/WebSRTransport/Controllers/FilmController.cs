using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebSRTransport.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSRTransport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IHubContext<FilmHub> _hubContext;

        public FilmController(IHubContext<FilmHub> hubContext) : base()
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
            await _hubContext.Clients.All.SendAsync("Send", msg);
        }

        [HttpGet("{msg}")]
        public async void Notify(string msg)
        {
            await _hubContext.Clients.All.SendAsync("Notify", msg);
        }
    }
}
