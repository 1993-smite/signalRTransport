using Common.lib.cqrs.commands.Commands;
using DB.DBModels;
using DB.Repositories;
using DB.Repositories.User;

namespace DB.lib.commands.User.Get
{
    public class UserList
        : CommandListHandler<DBUser, UserFilter>
    {
        public UserList(ICommonGetRepository<DBUser, UserFilter> repository)
            : base(repository)
        {

        }
    }
}
