using Common.lib.cqrs.commands.Commands;
using DB.DBModels;

namespace DB.lib.commands.User.Save
{
    public class UserSaveCommand: Command<DBUser, DBUser>
    {
        public UserSaveCommand(DBUser model): base(model)
        {

        }
    }
}
