using NUnit.Framework;
using WebAPI.Models;

namespace WebAPITest.Test
{
    [TestFixture]
    public class PlaceTest
    {
        [Test]
        public void PlaceValidationTest()
        {
            var place = new Place();
            var validation = new PlaceValidation();

            var result = validation.Validate(place);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(result.Errors.Count, 1);
        }
    }
}
