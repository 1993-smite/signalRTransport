using WebAPI.Models;

namespace WebAPI.Sevices.Route
{
    public class RouteData : Itinero.Route
    {
        public PlaceCoord From { get; private set; }
        public PlaceCoord To { get; private set; }

        public RouteData(PlaceCoord from, PlaceCoord to)
        {
            From = from;
            To = to;
        }

        public RouteData(PlaceCoord from, PlaceCoord to, float distance) : this(from, to)
        {
            TotalDistance = distance;
        }

        public RouteData(PlaceCoord from, PlaceCoord to, float distance, float time) : this(from, to, distance)
        {
            TotalTime = time;
        }

        public RouteData(Itinero.Route route)
        {
            SetRouteData(route.TotalDistance, route.TotalTime);
        }

        public void SetRouteData(float distance, float time)
        {
            TotalDistance = distance;
            TotalTime = time;
        }
    }
}
