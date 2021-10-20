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
        [HttpPost]
        public ActionResult<Cluster<GeographicPoint>> Clusterize(List<Place> places, int count)
        {
            var clusterizer = new Clusterization<GeographicPoint>();
            var clusters = clusterizer.Clusterize(places.Select(x => new GeographicPoint((double)x.Lat, (double)x.Lon)), count);
            return Ok(clusters.Select(x=>new ClusterView(x)));
        }
    }
}
