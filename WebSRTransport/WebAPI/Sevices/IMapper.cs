using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Sevices
{
    interface IMapper<TModel>
    {
        public IEnumerable<TModel> Get();
        public TModel Get(long id);
        public long Save(TModel task);
    }
}
