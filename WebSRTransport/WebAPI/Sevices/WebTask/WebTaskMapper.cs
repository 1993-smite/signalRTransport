using DB.Repositories;
using DB.Repositories.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Sevices
{
    public class WebTaskMapper: IMapper<WebTask, TaskFilter>
    {
        private Lazy<TaskRepository> _rep = new Lazy<TaskRepository>(()=> new TaskRepository());
        private TaskRepository TaskRepository => _rep.Value;
        private Lazy<WebTaskConverter> _converter = new Lazy<WebTaskConverter>(()=> new WebTaskConverter());
        private WebTaskConverter WebTaskConverter => _converter.Value;

        public IEnumerable<WebTask> GetList(TaskFilter filter = default(TaskFilter))
        {
            var tasks = TaskRepository.GetList(filter);

            return tasks.Select(x => WebTaskConverter.toView(x));
        }

        public WebTask Get(TaskFilter filter)
        {
            var dbtask = TaskRepository.Get(filter);
            return WebTaskConverter.toView(dbtask);
        }

        public long Save(WebTask task)
        {
            var dbtask = WebTaskConverter.toDB(task);
            return TaskRepository.SaveTransaction(dbtask).Id;
        }
    }
}
