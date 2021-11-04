using System;
using System.Collections.Generic;

namespace DBDapper
{
    /// <summary>
    /// base dapper repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDapperRepository<T>
    {
        /// <summary>
        /// create item
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// delete item
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// get list items
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetList();

        /// <summary>
        /// update item
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
    }
}
