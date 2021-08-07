using DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Sevices.Address
{
    public class PlaceMapper
    {
        private PlaceConverter _converter = new PlaceConverter();

        public IEnumerable<Place> Get(string filter = "", int count = 10)
        {
            return AddressRepository.Get(filter, count).Select(x=> _converter.toView(x));
        }

        public void Save(Place place)
        {
            var dbplace = _converter.toDB(place);
            AddressRepository.Save(dbplace);
        }
    }
}
