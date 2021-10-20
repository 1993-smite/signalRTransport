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
    }
}
