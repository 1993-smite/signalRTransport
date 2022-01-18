using Common.lib.cqrs.commands.Commands;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.Task;
using MediatR;

namespace DB.lib.commands.Task
{
    public class TaskSave : CommandSaveHandler<DBTask, TaskFilter>
    {
        public TaskSave(IMediator mediator, CommonRepository<DBTask, TaskFilter> repository)
            : base(mediator, repository)
        {

        }
    }
}
