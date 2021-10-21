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
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterizeController : ControllerBase
    {
        //[HttpPost]
        //public ActionResult<Cluster<GeographicPoint>> Post([FromBody] ClusterizeParam param)
        //{
        //    var clusterizer = new Clusterization<CartesianPoint>();
            
        //    var geographic = new List<GeographicPoint>();
        //    var xy = new List<CartesianPoint>();
        //    for(int i = 0; i < param.Places.Length; i++)
        //    {
        //        var place = param.Places[i];
        //        var geographicPoint = new GeographicPoint(i + 1, (double)place.Lat, (double)place.Lon);
        //        geographic.Add(geographicPoint);
        //        xy.Add(geographicPoint.toCartesian());
        //    }

        //    var clusters = clusterizer
        //        .Clusterize(xy, param.Count);
        //    var geographicClusters = new List<Cluster<GeographicPoint>>();
        //    foreach (var cluster in clusters)
        //    {
        //        geographicClusters.Add(new Cluster<GeographicPoint>()
        //        {
        //            Items = cluster.Items.Select(x => geographic.FirstOrDefault(p => p.Id == x.Id)).ToList()
        //        });
        //    }

        //    var res = geographicClusters.Select(x => new ClusterView(x));
        //    return Ok(res);
        //}

        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> Post([FromBody] ClusterizeParam param)
        {
            var clusterizer = new Clusterization<GeographicPoint>();
            var clusters = clusterizer
                .Clusterize(param.Places.Select(x=>new GeographicPoint(0,(double)x.Lat, (double)x.Lon)), param.Count);
            var res = clusters.Select(x => new ClusterView(x));
            return Ok(res);
        }
    }
}
