using Common.lib.cqrs.commands.Commands;
using DB.DBModels;
using DB.Repositories;
using MediatR;

namespace DB.lib.commands.User.Save
{
    public class UserSave: CommandSaveHandler<DBUser>
    {
        public UserSave(IMediator mediator, ICommonSaveRepository<DBUser> repository)
            : base(mediator, repository)
        {

        }
    }
}
