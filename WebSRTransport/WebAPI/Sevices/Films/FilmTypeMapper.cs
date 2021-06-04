using WebAPI.Models;
using PostgresApp;
using System;
using System.Collections.Generic;
using System.Linq;
using DB.DBModels;
using DB.Repositories;

namespace WebAPI.Services
{
    public class FilmTypeMapper
    {
        private FilmTypeRepository _repository;
        private FilmTypeConverter _converter;

        public FilmTypeMapper()
        {
            _repository = new FilmTypeRepository();
            _converter = new FilmTypeConverter();
        }

        /// <summary>
        /// get film type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FilmType Get(int id)
        {
            DBFilmType dBFilmType = _repository.Get(id);

            var type = _converter.toView(dBFilmType);

            return type;
        }

        /// <summary>
        /// get list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FilmType> Get()
        {
            var dbTypes = _repository.Get();
            var types = new List<FilmType>();

            foreach (var dbType in dbTypes)
            {
                types.Add(_converter.toView(dbType));
            }
            return types;
        }

    }
}
