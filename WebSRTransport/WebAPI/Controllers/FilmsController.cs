using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private Lazy<FilmMapper> _db = new Lazy<FilmMapper>(() => new FilmMapper());

        // GET list
        [HttpGet]
        public ActionResult<Tuple<IEnumerable<Film>,long>> Get(int page = 1
            , int pageCount = 20
            , string name = ""
            , int year = 0
            , int type = 0)
        {
            return Ok(_db.Value.GetFilms(page, pageCount, name, year, type));
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://localhost:1040/api/film/id");
            //WebResponse response = request.GetResponse();
            return Ok(_db.Value.GetFilm(id));
        }

        // POST
        [HttpPost]
        public ActionResult<long> Post(FilmValid film)
        {
            var res = _db.Value.SaveFilm(film);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://localhost:1040/api/film/saved_film_{film.Id}-{film.Name}");
            WebResponse response = request.GetResponse();
            return Ok(res);
        }

        // Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Value.DeleteFilm(id);
        }
    }
}
