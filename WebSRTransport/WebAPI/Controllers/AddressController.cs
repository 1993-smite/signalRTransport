using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Clasterization;
using Clasterization.Location;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Sevices;
using WebAPI.Sevices.Address;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private PlaceMapper _mapper = new PlaceMapper();

        /// <summary>
        /// получение списка мест
        /// </summary>
        /// <param name="filter">фильтр по имени</param>
        /// <param name="count">фильтр по количеству</param>
        /// <returns></returns>
        // GET: api/Address
        [HttpGet]
        public ActionResult<IEnumerable<Place>> Get(string filter = "", int count = 10)
        {
            return Ok(_mapper.Get(filter, count));
        }

        /// <summary>
        /// сохранение места
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        // POST: api/Address
        [HttpPost]
        public ActionResult<long> Post([FromBody] PlaceValid place)
        {
            _mapper.Save((Place)place);
            return Ok();
        }
    }
}
