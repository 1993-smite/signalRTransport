using DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Sevices
{
    public class WebTaskMapper
    {
        private WebTaskConverter _converter = new WebTaskConverter();

        public List<WebTask> Get()
        {
            var tasks = TaskRepository.GetTasks();

            return tasks.Select(x => _converter.toView(x)).ToList();
        }

        public WebTask Get(int id)
        {
            var dbtask = TaskRepository.GetTask(id);
            return _converter.toView(dbtask);
        }

        public long Save(WebTask task)
        {
            var dbtask = _converter.toDB(task);
            return TaskRepository.SaveTask(dbtask);
        }
    }
}
