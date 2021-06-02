using WebAPI.Models;
using DB.DBModels;

namespace WebAPI.Services
{
    public class FilmTypeConverter : Converter<DBFilmType, FilmType>
    {
        public DBFilmType toDB(FilmType from)
        {
            var to = new DBFilmType()
            {
                Id = from.Id,
                Name = from.Name
            };
            return to;
        }

        public FilmType toView(DBFilmType from)
        {
            var to = new FilmType()
            {
                Id = from?.Id ?? 0,
                Name = from?.Name ?? "",
            };
            return to;
        }
    }
}
