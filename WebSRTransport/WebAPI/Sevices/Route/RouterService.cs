using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;
using System.Diagnostics;
using System.IO;

namespace WebAPI.Sevices
{

    interface IRouterService
    {
        Router GetCachedRouter(string key = null);
    }

    /// <summary>
    /// route service
    /// </summary>
    public class RouterService: IRouterService
    {
        private const string Key = "RouterDefaultKey";
        private Cache<Router> _cache;
        private string path = @"D:\Moscow.osm.pbf";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="cache"></param>
        public RouterService(string filePath,Cache<Router> cache = null)
        {
            path = filePath;
            _cache = cache ?? new Cache<Router>();
        }

        private Router GetRouter()
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            var routerDb = new RouterDb();
            using (var stream = new FileInfo(path).OpenRead())
            {
                routerDb.LoadOsmData(stream, Vehicle.Car);
            }

            stopWatch.Stop();
            var dt = stopWatch.Elapsed;

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
