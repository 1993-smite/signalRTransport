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
        private IEnumerable<ClusterView> clusterize(Clusterization<GeographicPoint> clusterizer, ClusterizeParam param)
        {
            var clusters = clusterizer
                .Clusterize(param.Places.Select(x => new GeographicPoint(0, (double)x.Lat, (double)x.Lon)), param.Count);
            return clusters.Select(x => new ClusterView(x));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordKMeans([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<GeographicPoint>(ClusterizationMode.Kmeans);
            return Ok(clusterize(clusterizer, param));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordBinarySplit([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<GeographicPoint>(ClusterizationMode.BinarySplit);
            return Ok(clusterize(clusterizer, param));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordMeanSplit([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<GeographicPoint>(ClusterizationMode.MeanSplit);
            return Ok(clusterize(clusterizer, param));
        }

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> AccordGausian([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<GeographicPoint>(ClusterizationMode.Gausian);
            return Ok(clusterize(clusterizer, param));
        }
    }
}
