using WebAPI.Models;
using DB.DBModels;
using WebAPI.Services;

namespace WebAPI.Sevices
{
    public class PlaceConverter : IConverter<DBAddress, Place>
    {
        public PlaceConverter()
        {
        }

        public DBAddress toDB(Place from)
        {
            var to = new DBAddress()
            {
                Address = from.Address,
                Lat = from.Lat,
                Lon = from.Lon
            };
            return to;
        }

        public Place toView(DBAddress from)
        {
            var to = new Place()
            {
                Address = from.Address,
                Lon = from.Lon,
                Lat = from.Lat
            };
            return to;
        }
    }
}
