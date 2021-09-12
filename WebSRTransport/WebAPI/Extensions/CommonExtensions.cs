using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class CommonExtensions
    {
        public static TCast Cast<TBase, TCast>(this TBase from) 
            where TCast : class 
            where TBase : class
        {
            return from is TCast
                ? from as TCast
                : null;
        }
        
        public static TypeTo CastTo<TypeFrom, TypeTo>(this TypeFrom from)
            where TypeFrom : TypeTo
            where TypeTo : class
        {
            return from as TypeTo;
        }
    }
}
