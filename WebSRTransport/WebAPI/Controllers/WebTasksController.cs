using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Repositories.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Sevices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebTasksController : ControllerBase
    {
        public readonly IMapper<WebTask, TaskFilter> WebTaskMapper;

        public WebTasksController(IMapper<WebTask, TaskFilter> webTaskMapper)
        {
            WebTaskMapper = webTaskMapper;
        }

        // GET: api/WebTasks
        /// <summary>
        /// получение списка тасков
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<WebTask>> Get()
        {
            return Ok(WebTaskMapper.GetList());
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
            return Ok(WebTaskMapper.Get(new TaskFilter(id)));
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
            return Ok(WebTaskMapper.Save((WebTask)task));
        }
    }
}
