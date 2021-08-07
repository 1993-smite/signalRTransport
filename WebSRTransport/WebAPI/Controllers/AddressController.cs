using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Sevices.Address;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private PlaceMapper _mapper = new PlaceMapper();

        // GET: api/Address
        [HttpGet]
        public ActionResult<IEnumerable<Place>> Get(string filter = "", int count = 10)
        {
            return Ok(_mapper.Get(filter, count));
        }

        // POST: api/WebTasks
        [HttpPost]
        public ActionResult<long> Post([FromBody] PlaceValid place)
        {
            _mapper.Save((Place)place);
            return Ok();
        }
    }
}
