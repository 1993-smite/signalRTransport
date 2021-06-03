using DB.DBModels;
using NUnit.Framework;
using System;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPITest.Services
{
    [TestFixture]
    public class FilmConverterTest
    {
        private Lazy<FilmConverter> _converter = new Lazy<FilmConverter>(()=>new FilmConverter());


        private Film getFilm(int index)
        {
            return new Film()
            {
                Id = index,
                Name = $"Test {index}",
                Type = new FilmType() { Id = index },
                Year = 2000 + index,
                Description = $"Description {index}",
                Country = $"Country {index}",
                Timing = index,
                Budget = 1000 + index,
                State = FilmState.Active
            };
        }

        private void checkFilm(Film domain, DBFilm db)
        {
            Assert.AreEqual(domain.Id, db.Id);
            Assert.AreEqual(domain.Name, db.Name);
            Assert.AreEqual(domain.Description, db.Descriptions);
            Assert.AreEqual(domain.Country, db.Country);
            Assert.AreEqual((int)domain.State, db.Status);
            Assert.AreEqual(domain.Type.Id, db.TypeId);
            Assert.AreEqual(domain.Timing, db.Timing);
            Assert.AreEqual(domain.Budget, db.Budget);
        }

        [Test]
        public void toDBTest([Range(0, 10, 2)] int index)
        {
            var domain = getFilm(index);
            var db = _converter.Value.toDB(domain);

            checkFilm(domain, db);
        }

        [Test]
        public void toViewTest([Range(0, 10, 2)] int index)
        {
            var dmn = getFilm(index);
            var db = _converter.Value.toDB(dmn);
            var domain = _converter.Value.toView(db);

            checkFilm(domain, db);
        }
    }
}
