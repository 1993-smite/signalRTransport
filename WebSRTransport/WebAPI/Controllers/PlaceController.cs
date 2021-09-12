using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Sevices;
using WebAPI.Sevices.Address;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        // GET: api/Address
        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "param" })]
        public ActionResult<PlaceAnswer> Get(string param)
        {
            string url = $"http://router.project-osrm.org/table/v1/driving/{param}?annotations=distance,duration";
            var request = new Request();

            var answer = request.GetData(url);
            var typed = JsonSerializer.Deserialize<PlaceAnswer>(answer);

            return Ok(typed);
        }

        [HttpPost]
        public ActionResult<PlaceAnswer> Post(Place[] places)
        {
            string param = "";
            foreach (var place in places)
                param += $"{place.Lon.ToString().Replace(',','.')},{place.Lat.ToString().Replace(',', '.')};";

            return RedirectToAction("Get", new { param = param.Trim(';') });
        }

        //private PlaceAnswer getMatrix(string param)
        //{
        //    string url = $"http://router.project-osrm.org/table/v1/driving/{param}?annotations=distance,duration";
        //    var request = new Request();

        //    var answer = request.GetData(url);
        //    var typed = JsonSerializer.Deserialize<PlaceAnswer>(answer);

        //    return typed;
        //}
    }
}
