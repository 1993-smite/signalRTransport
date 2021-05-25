using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Sevices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebTasksController : ControllerBase
    {
        private WebTaskMapper _mapper = new WebTaskMapper();

        // GET: api/WebTasks
        [HttpGet]
        public ActionResult<IEnumerable<WebTask>> Get()
        {
            return Ok(_mapper.Get());
        }

        // GET: api/WebTasks/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<WebTask> Get(int id)
        {
            return Ok(_mapper.Get(id));
        }

        // POST: api/WebTasks
        [HttpPost]
        public ActionResult<long> Post([FromBody] WebTaskValid task)
        {
            return Ok(_mapper.Save((WebTask)task));
        }
    }
}
