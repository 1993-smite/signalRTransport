using DB.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Common.lib.cqrs.commands.Commands.Answer;
using System.Collections.Generic;

namespace Common.lib.cqrs.commands.Commands
{
    public class CommandListHandler<TModel, TFilter>
    {
        protected readonly ICommonGetRepository<TModel, TFilter> _repository;

        public CommandListHandler(ICommonGetRepository<TModel, TFilter> repository)
        {
            _repository = repository;   
        }


        public virtual Task<Answer<IEnumerable<TModel>>> Handle(Command<TFilter, TModel> request, CancellationToken cancellationToken)
        {
            var mdls = _repository.GetList(request.Model);

            return Task.FromResult(new Answer<IEnumerable<TModel>>(mdls, AnswerState.Done));
        }
    }
}
