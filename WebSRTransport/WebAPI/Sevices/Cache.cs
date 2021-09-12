using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Sevices
{
    public class Cache<TItem>
    {
        private IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public Cache(IMemoryCache cache = null)
        {
            _cache = cache ?? new MemoryCache(new MemoryCacheOptions());
        }

        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry)) // Ищем ключ в кэше.
            {
                // Ключ отсутствует в кэше, поэтому получаем данные.
                cacheEntry = createItem();

                // Сохраняем данные в кэше. 
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
