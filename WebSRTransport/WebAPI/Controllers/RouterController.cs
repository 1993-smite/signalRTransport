using Itinero;
using Itinero.Geo;
using Itinero.Osm.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Sevices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RouterController: ControllerBase
    {
        private const string RouterKey = "RouterKey";

        private Lazy<RouterService> routerService;
        public RouterService RouterService => routerService.Value;

        public RouterController(IMemoryCache memoryCache)
        {
            routerService = new Lazy<RouterService>(() => new RouterService(new Cache<Router>(memoryCache)));
        }

        [HttpPost]
        public ActionResult Route([FromBody]PlaceCoordValid[] places)
        {
            if (places == null || places.Length < 2)
                throw new ArgumentOutOfRangeException($"Param {nameof(places)} not available");

            var router = RouterService.GetCachedRouter(RouterKey);
            var routes = new List<Route>(places.Length);

            int lastIndex = 0;
            for(int index = 1; index < places.Length; index++)
            {
                routes.Add(router.Calculate(Vehicle.Car.Fastest(),
                     Decimal.ToSingle(places[lastIndex].Lat)
                    , Decimal.ToSingle(places[lastIndex].Lon)
                    , Decimal.ToSingle(places[index].Lat)
                    , Decimal.ToSingle(places[index].Lon)
                ));
                lastIndex = index;
            }


            return Ok(routes.Select(x=>x.ToGeoJson()));
        }

    }
}
