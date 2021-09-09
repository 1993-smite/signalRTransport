using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace WebAPITest.Test
{
    [TestFixture]
    class CopyTest
    {
        [Test]
        public void CopyFilm()
        {
            var film = new Film() 
            { 
                Id = 1,
                Name = "Test",
                Type = new FilmType()
                {
                    Id = 9999,
                    Name = "Type"
                },
                State = FilmState.Active
            };

            // Настройка конфигурации AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Film,Film>());
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            var copy = mapper.Map<Film, Film>(film);

            Assert.AreEqual(film.Id, copy.Id);
            Assert.AreEqual(film.Name, copy.Name);
            Assert.AreEqual(film.Type.Id, copy.Type.Id);

            film.Type.Id = 1111;

            Assert.AreEqual(film.Type, copy.Type);
        }

        [Test]
        public void Cast()
        {

        }
    }
}
