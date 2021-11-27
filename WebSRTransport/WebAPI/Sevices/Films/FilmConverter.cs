using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using DB.DBModels;

namespace WebAPI.Services
{
    public class FilmConverter: IConverter<DBFilm, Film>
    {
        private List<FilmType> _types = new List<FilmType>();

        public FilmConverter()
        {
        }

        public FilmConverter SetTypes(IEnumerable<FilmType> types = null)
        {
            if (_types != null)
                _types.AddRange(types);
            return this;
        }

        public FilmConverter SetType(FilmType type)
        {
            if (type != null)
                _types.Add(type);
            return this;
        }

        public DBFilm toDB(Film from)
        {
            var to = new DBFilm()
            {
                Id = from.Id,
                Name = from.Name,
                TypeId = from.Type?.Id ?? 0,
                Year = from.Year,
                Descriptions = from.Description,
                Country = from.Country,
                Budget = from.Budget,
                Timing = from.Timing,
                Status = (int)from.State
            };
            return to;
        }

        public Film toView(DBFilm from)
        {
            var to = new Film()
            {
                Id = (int)from.Id,
                Name = from.Name,
                Type = _types?.FirstOrDefault(x=>x.Id == from.TypeId) ?? new FilmType() { Id = from.TypeId },
                Year = from.Year,
                Description = from.Descriptions,
                Country = from.Country,
                Budget = from.Budget.HasValue ? from.Budget.Value : 0,
                Timing = from.Timing.HasValue ? from.Timing.Value : 0,
                State = (FilmState)from.Status
            };
            return to;
        }
    }
}
