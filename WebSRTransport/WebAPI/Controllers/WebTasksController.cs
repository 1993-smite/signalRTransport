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
        /// <summary>
        /// получение списка тасков
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<WebTask>> Get()
        {
            return Ok(_mapper.Get());
        }

        /// <summary>
        /// получение одного таска
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/WebTasks/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<WebTask> Get(int id)
        {
            return Ok(_mapper.Get(id));
        }

        /// <summary>
        /// сохранение таска с валидацией
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        // POST: api/WebTasks
        [HttpPost]
        public ActionResult<long> Post([FromBody] WebTaskValid task)
        {
            return Ok(_mapper.Save((WebTask)task));
        }
    }
}
