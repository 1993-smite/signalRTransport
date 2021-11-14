using Clasterization;
using Clasterization.Location;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClusterizeController : ControllerBase
    {
        public readonly CartesianPoint Base = new GeographicPoint(0, 55.77162551879, 37.7147102355).toCartesian();
        private IEnumerable<ClusterView> clusterize(Clusterization<RelativeGeographicPoint> clusterizer, ClusterizeParam param)
        {
            var pnts = param
                    .Places
                    .Select(x => new RelativeGeographicPoint(Base, new GeographicPoint(0, (double)x.Lat, (double)x.Lon)));
            var clusters = clusterizer
                .Clusterize(pnts, param.Count);
            return clusters.Select(x => new ClusterView(x));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordKMeans([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<RelativeGeographicPoint>(ClusterizationMode.Kmeans);
            return Ok(clusterize(clusterizer, param));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordBinarySplit([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<RelativeGeographicPoint>(ClusterizationMode.BinarySplit);
            return Ok(clusterize(clusterizer, param));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordMeanSplit([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<RelativeGeographicPoint>(ClusterizationMode.MeanSplit);
            return Ok(clusterize(clusterizer, param));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordGausian([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<RelativeGeographicPoint>(ClusterizationMode.Gausian);
            return Ok(clusterize(clusterizer, param));
        }
    }
}
