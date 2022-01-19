using Common.lib.cqrs.commands.Commands;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.Task;
using MediatR;

namespace DB.lib.commands.TaskCommands
{
    public class TaskSave : CommandSaveHandler<DBTask>
    {
        public TaskSave(IMediator mediator, ICommonSaveRepository<DBTask> repository)
            : base(mediator, repository)
        {

        }
    }
}
