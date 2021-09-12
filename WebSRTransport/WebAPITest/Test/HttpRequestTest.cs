using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Sevices;
using WebAPI.Sevices.Address;

namespace WebAPITest.Test
{
    [TestFixture]
    class HttpRequestTest
    {
        [Test]
        public void GetDataTest()
        {
            var request = new Request();

            string url = "http://router.project-osrm.org/table/v1/driving/" +
                "13.388860,52.517037;13.397634,52.529407;13.428555,52.523219?annotations=distance,duration";

            var answer = request.GetData(url);
            var typed = JsonSerializer.Deserialize<PlaceAnswer>(answer);
        }
    }
}
