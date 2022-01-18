using MediatR;
using Common.lib.cqrs.commands.Commands.Answer;

namespace Common.lib.cqrs.commands.Commands
{
    public class SingleCommand<TModel>: IRequest<Answer<TModel>>
    {
        public TModel Model;

        public SingleCommand(TModel model)
        {
            Model = model;
        }
    }
}
