using Common.lib.cqrs.commands.Commands;
using Common.lib.cqrs.commands.Commands.Answer;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.Task;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.lib.commands.Task
{
    public class TaskList : CommandListHandler<DBTask, TaskFilter>
    {
        public TaskList(IMediator mediator, CommonRepository<DBTask, TaskFilter> repository)
            : base(mediator, repository)
        {

        }

    }
}
