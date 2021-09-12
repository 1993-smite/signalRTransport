using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Models;
using WebAPI.Sevices;
using WebAPI.Sevices.Address;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private Cache<PlaceAnswer> _cache;
        public PlaceController(IMemoryCache memoryCache)
        {
            _cache = new Cache<PlaceAnswer>(memoryCache);
        }

        // GET: api/Address
        [HttpGet]
        public ActionResult<PlaceAnswer> Get(string param)
        {
            return Ok(getCachesMatrix(param));
        }

        [HttpPost]
        public ActionResult<PlaceAnswer> Post(Place[] places)
        {
            string param = "";
            foreach (var place in places)
                param += $"{place.Lon.ToString().Replace(',','.')},{place.Lat.ToString().Replace(',', '.')};";

            return getCachesMatrix(param);
        }

        private PlaceAnswer getCachesMatrix(string param)
        {
            return _cache.GetOrCreate(param, () => getMatrix(param));
        }

        private PlaceAnswer getMatrix(string param)
        {
            string url = $"http://router.project-osrm.org/table/v1/driving/{param}?annotations=distance,duration";
            var request = new Request();

            var answer = request.GetData(url);
            var typed = JsonSerializer.Deserialize<PlaceAnswer>(answer);

            return typed;
        }
    }
}
