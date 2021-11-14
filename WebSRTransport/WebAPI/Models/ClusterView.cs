using Clasterization.Location;
using Clasterization;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models
{
    public class ClusterView
    {
        public IEnumerable<Place> Points { get; }

        public ClusterView(Cluster<GeographicPoint> cluster)
        {
            Points = cluster.Items.Select(x => new Place() { Lat = (decimal)x.Lat, Lon = (decimal)x.Lon });
        }

        public ClusterView(Cluster<RelativeGeographicPoint> cluster)
        {
            Points = cluster.Items.Select(x => new Place() { Lat = (decimal)x.GeographicPoint().Lat, Lon = (decimal)x.GeographicPoint().Lon });
        }

        public ClusterView(Cluster<CartesianPoint> cluster)
        {
            var points = new List<Place>();
            foreach(var item in cluster.Items)
            {
                var it = item.toGeographic();
                points.Add(new Place()
                {
                    Lat = (decimal)it.Lat,
                    Lon = (decimal)it.Lon
                });
            }
        }
    }

    public class ClusterizeParam
    {
        public Place[] Places { get; set; }
        public int Count { get; set; }
    }
}
