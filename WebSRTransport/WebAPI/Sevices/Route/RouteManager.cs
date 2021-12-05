using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Sevices.Route
{
    interface IRouteManager
    {
        RouteData GetRouteData(PlaceCoord from, PlaceCoord to);
    }

    public class RouteManager : IRouteManager
    {
        private Func<PlaceCoord, PlaceCoord, RouteData> getRoute;
        public RouteManager(Func<PlaceCoord, PlaceCoord, RouteData> route)
        {
            getRoute = route;
        }

        public RouteData GetRouteData(PlaceCoord from, PlaceCoord to)
        {
            RouteData route;
            try
            {
                route = getRoute.Invoke(from, to);
            }
            catch (Exception err)
            {
                var distance = from.toGeographic().Distance(to.toGeographic());
                route = new RouteData(from, to, (float)distance);
            }

            return route;
        }

        public IList<IList<RouteData>> GetMatrixData(IList<PlaceCoord> places)
        {
            var count = places.Count;
            var matrix = new RouteData[count][];
            for (int y = 0; y < count; y++)
            {
                matrix[y] = new RouteData[count];
                for (int x = 0; x < count; x++)
                {
                    matrix[y][x] = x == y 
                        ? new RouteData(places[y], places[x], 0, 0) 
                        : GetRouteData(places[y], places[x]);
                }
            }

            return matrix;
        }
    }
}
