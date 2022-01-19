using Common.lib.cqrs.commands.Commands;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.Task;

namespace DB.lib.commands.TaskCommands
{
    public class TaskList : CommandListHandler<DBTask, TaskFilter>
    {
        public TaskList(ICommonGetRepository<DBTask, TaskFilter> repository)
            : base(repository)
        {

        }

    }
}
