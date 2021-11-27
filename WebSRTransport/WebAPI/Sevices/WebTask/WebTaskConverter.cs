using WebAPI.Models;
using DB.DBModels;
using WebAPI.Services;

namespace WebAPI.Sevices
{
    public class WebTaskConverter : IConverter<DBTask, WebTask>
    {
        public WebTaskConverter()
        {
        }

        public DBTask toDB(WebTask from)
        {
            var to = new DBTask()
            {
                Id = from.Id,
                Name = from.Name,
                Date = from.Date,
                Status = (int)from.Status
            };
            return to;
        }

        public WebTask toView(DBTask from)
        {
            var to = new WebTask()
            {
                Id = (int)from.Id,
                Name = from.Name,
                Date = from.Date,
                Status = (WebTaskStatus)from.Status
            };
            return to;
        }
    }
}
