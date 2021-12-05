using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Sevices
{
    public class RouterService
    {
        private const string Key = "RouterDefaultKey";
        private Cache<Router> _cache;
        public RouterService(Cache<Router> cache = null)
        {
            _cache = cache ?? new Cache<Router>();
        }

        private Router GetRouter()
        {
            var routerDb = new RouterDb();
            using (var stream = new FileInfo(@"D:\Moscow.osm.pbf").OpenRead())
            {
                routerDb.LoadOsmData(stream, Vehicle.Car);
            }
            var router = new Router(routerDb);

            return router;
        }

        public Router GetCachedRouter(string key = null)
        {
            if (string.IsNullOrEmpty(key))
                key = Key;

            return _cache.GetOrCreate(key, () => GetRouter());
        }
    }
}
