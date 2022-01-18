using Common.lib.cqrs.commands.Commands;
using Common.lib.cqrs.commands.Commands.Answer;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.lib.commands.User
{
    public class UserList
        : CommandListHandler<DBUser, UserFilter>
    {
        public UserList(IMediator mediator, CommonRepository<DBUser, UserFilter> repository)
            : base(mediator, repository)
        {

        }
    }
}
