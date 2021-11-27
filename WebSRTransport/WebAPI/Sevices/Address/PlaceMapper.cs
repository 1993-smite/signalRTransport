using DB.Repositories.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Sevices.Address
{
    public class PlaceMapper : IMapper<Place>
    {
        private Lazy<AddressRepository> _rep = new Lazy<AddressRepository>(()=> new AddressRepository());
        AddressRepository AddressRepository => _rep.Value;

        private Lazy<PlaceConverter> _converter = new Lazy<PlaceConverter>(() => new PlaceConverter());
        PlaceConverter PlaceConverter => _converter.Value;


        public IEnumerable<Place> Get(string filter = "", int count = 10)
        {
            return AddressRepository.GetList(new AddressFilter(filter, count)).Select(x=> PlaceConverter.toView(x));
        }

        public IEnumerable<Place> Get()
        {
            throw new NotImplementedException();
        }

        public Place Get(long id)
        {
            throw new NotImplementedException();
        }

        public long Save(Place place)
        {
            var dbplace = PlaceConverter.toDB(place);
            AddressRepository.SaveTransaction(dbplace);
            return 1;
        }
    }
}
