using System;
using System.Collections.Generic;
using System.Text;

namespace DBDapper
{
    public class DapperRepository<T>: IDapperRepository<T>
    {
        protected string connectionString;
        public DapperRepository(string conn)
        {
            connectionString = conn;
        }

        public virtual void Create(T item)
        {
            throw new NotImplementedException();
        }
        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<T> GetList()
        {
            throw new NotImplementedException();
        }
        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
