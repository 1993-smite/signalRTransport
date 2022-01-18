using DB.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Common.lib.cqrs.commands.Commands.Answer;

namespace Common.lib.cqrs.commands.Commands
{
    public class CommandSaveHandler<TModel, TFilter>
        : CommandHandler<TModel, TFilter, TModel>
    {
        public CommandSaveHandler(IMediator mediator, CommonRepository<TModel, TFilter> repository)
            : base(mediator, repository)
        {
            
        }


        public virtual Task<Answer<TModel>> Handle(Command<TModel, TModel> request, CancellationToken cancellationToken)
        {
            var mdl = _repository.SaveTransaction(request.Model);

            return Task.Run(()=> new Answer<TModel>(mdl, AnswerState.Done));
        }
    }
}
