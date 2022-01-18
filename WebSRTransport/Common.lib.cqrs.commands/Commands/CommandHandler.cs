using DB.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Common.lib.cqrs.commands.Commands.Answer;

namespace Common.lib.cqrs.commands.Commands
{
    public class CommandHandler<TModel, TFilter, TOutModel>
        : IRequestHandler<Command<TFilter, TOutModel>, Answer<TOutModel>>
    {
        protected readonly IMediator _mediator;
        protected readonly CommonRepository<TModel, TFilter> _repository;

        public CommandHandler(IMediator mediator, CommonRepository<TModel, TFilter> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        
        public virtual Task<Answer<TOutModel>> Handle(Command<TFilter, TOutModel> request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
