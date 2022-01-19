using DB.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Common.lib.cqrs.commands.Commands.Answer;

namespace Common.lib.cqrs.commands.Commands
{
    public class CommandSaveHandler<TModel>
        : IRequestHandler<Command<TModel, TModel>, Answer<TModel>>
    {
        protected readonly IMediator _mediator;
        protected readonly ICommonSaveRepository<TModel> _repository;

        public CommandSaveHandler(IMediator mediator, ICommonSaveRepository<TModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public Task<Answer<TModel>> Handle(Command<TModel, TModel> request, CancellationToken cancellationToken)
        {
            var mdl = _repository.SaveTransaction(request.Model);

            return Task.FromResult(new Answer<TModel>(mdl, AnswerState.Done));
        }
    }
}
