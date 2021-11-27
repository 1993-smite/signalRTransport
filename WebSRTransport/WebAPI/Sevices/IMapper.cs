using DB.Repositories;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI.Sevices
{
    public interface IMapper<TModel, TFilter> where TFilter: Filter
    {
        public IEnumerable<TModel> GetList(TFilter filter = default(TFilter));
        public TModel Get([NotNull]TFilter filter);
        public long Save(TModel task);
    }
}
