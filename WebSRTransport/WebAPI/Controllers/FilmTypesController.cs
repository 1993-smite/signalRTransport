using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmTypesController : ControllerBase
    {
        private Lazy<FilmTypeMapper> _db = new Lazy<FilmTypeMapper>(() => new FilmTypeMapper());

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Film>> Get()
        {
            return Ok(_db.Value.Get());
        }
    }
}
