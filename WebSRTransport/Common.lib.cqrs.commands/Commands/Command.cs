using MediatR;
using Common.lib.cqrs.commands.Commands.Answer;

namespace Common.lib.cqrs.commands.Commands
{
    public class Command<TModel,TOutModel>: IRequest<Answer<TOutModel>>
    {
        public TModel Model;

        public Command(TModel model)
        {
            Model = model;
        }
    }
}
