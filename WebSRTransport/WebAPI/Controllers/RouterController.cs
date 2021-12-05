using Itinero;
using Itinero.Geo;
using Itinero.Osm.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Sevices;
using WebAPI.Sevices.Route;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RouterController: ControllerBase
    {
        private const string RouterKey = "RouterKey";
        private const string MapPath = "MapMoscowPath";

        private Lazy<RouterService> routerService;
        public RouterService RouterService => routerService.Value;

        public RouterController(IConfiguration configuration, IMemoryCache memoryCache)
        {
            string routePath = configuration.GetValue<string>(MapPath);

            routerService = new Lazy<RouterService>(() => new RouterService(routePath, new Cache<Router>(memoryCache)));
        }

        private RouteManager GetManager()
        {
            var router = RouterService.GetCachedRouter(RouterKey);

            Func<PlaceCoord, PlaceCoord, RouteData> getRoute = (PlaceCoord from, PlaceCoord to) => {
                return new RouteData(
                    router.Calculate(Vehicle.Car.Fastest()
                        , Decimal.ToSingle(from.Lat)
                        , Decimal.ToSingle(from.Lon)
                        , Decimal.ToSingle(to.Lat)
                        , Decimal.ToSingle(to.Lon)
                    ));
            };

            return new RouteManager(getRoute);
        }

        [HttpPost]
        public ActionResult Route([FromBody]PlaceCoordValid[] places)
        {
            if (places == null || places.Length < 2)
                throw new ArgumentOutOfRangeException($"Param {nameof(places)} not available");

            var routeManager = GetManager();
            var routes = new List<RouteData>(places.Length);

            int lastIndex = 0;
            for(int index = 1; index < places.Length; index++)
            {
                routes.Add(
                    routeManager.GetRouteData(
                        new PlaceCoord(places[lastIndex].Lat, places[lastIndex].Lon)
                        , new PlaceCoord(places[index].Lat, places[index].Lon)
                    )
                );
                lastIndex = index;
            }


            return Ok(routes.Select(x=>x.ToGeoJson()));
        }

        [HttpPost]
        public ActionResult Matrix([FromBody] PlaceCoordValid[] places, bool isTime = false)
        {
            if (places == null || places.Length < 2)
                throw new ArgumentOutOfRangeException($"Param {nameof(places)} not available");

            var routeManager = GetManager();
            var matrix = routeManager.GetMatrixData(places);

            var mtrx = matrix.Select(x => x.Select(x => x.TotalDistance));
            IEnumerable<IEnumerable<float>> time;

            if (isTime)
            {
                time = matrix.Select(x => x.Select(x => x.TotalTime));
                return Ok(new { Distances = mtrx, Times = time });
            }   

            return Ok(new { Distances = mtrx });
        }

    }
}
