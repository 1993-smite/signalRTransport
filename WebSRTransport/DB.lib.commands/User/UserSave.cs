using Common.lib.cqrs.commands.Commands;
using Common.lib.cqrs.commands.Commands.Answer;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DB.lib.commands.User
{
    public class UserSave: CommandSaveHandler<DBUser, UserFilter>
    {
        public UserSave(IMediator mediator, CommonRepository<DBUser, UserFilter> repository)
            : base(mediator, repository)
        {

        }
    }
}
