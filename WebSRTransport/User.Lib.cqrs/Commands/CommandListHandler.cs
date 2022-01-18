using DB.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Common.lib.cqrs.commands.Commands.Answer;
using System.Collections.Generic;

namespace Common.lib.cqrs.commands.Commands
{
    public class CommandListHandler<TModel, TFilter>
        : CommandHandler<TModel, TFilter, IEnumerable<TModel>>
    {
        
        public CommandListHandler(IMediator mediator, CommonRepository<TModel, TFilter> repository)
            : base(mediator, repository)
        {
            
        }


        public virtual Task<Answer<IEnumerable<TModel>>> Handle(Command<TFilter, TModel> request, CancellationToken cancellationToken)
        {
            var mdls = _repository.GetList(request.Model);

            return Task.Run(() => new Answer<IEnumerable<TModel>>(mdls, AnswerState.Done));
        }
    }
}
