using WebAPI.Models;
using PostgresApp;
using System;
using System.Collections.Generic;
using System.Linq;
using DB.DBModels;
using DB.Repositories;

namespace WebAPI.Services
{
    public class FilmMapper
    {
        private FilmConverter _converter;
        private FilmTypeConverter _typesConverter;
        private FilmRepository _repository;
        private FilmTypeMapper _filmTypeMapper;

        public FilmMapper()
        {
            _repository = new FilmRepository();
            _converter = new FilmConverter();
            _filmTypeMapper = new FilmTypeMapper();
            _typesConverter = new FilmTypeConverter();
        }

        /// <summary>
        /// get films by params
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageCount"></param>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="byType"></param>
        /// <returns></returns>
        public Tuple<IEnumerable<Film>, long> GetFilms(
            int page
            , int pageCount
            , string name = ""
            , int year = 0
            , int byType = 0
            )
        {
            var films = new List<Film>();
            var dbFilms = _repository.Get(page, pageCount, name, year, byType);
            long count = dbFilms.Item2;

            foreach (var dbFilm in dbFilms.Item1)
            {
                var type = _filmTypeMapper.Get(dbFilm.TypeId);

                films.Add(_converter
                            .SetType(type)
                            .toView(dbFilm));
            }

            return new Tuple<IEnumerable<Film>, long>(films, count);
        }

        /// <summary>
        /// get film by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Film GetFilm(int id)
        {
            DBFilm dBFilm = _repository.Get(id);

            var type = _filmTypeMapper.Get(dBFilm.TypeId);
            var film = _converter.SetType(type).toView(dBFilm);

            return film;
        }

        /// <summary>
        /// delete film by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFilm(int id)
        {
            _repository.DeleteFilm(id);
        }

        /// <summary>
        /// save film
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        public long SaveFilm(Film film)
        {
            var dbFilm = _converter.toDB(film);

            return _repository.Save(dbFilm);
        }
    }
}
