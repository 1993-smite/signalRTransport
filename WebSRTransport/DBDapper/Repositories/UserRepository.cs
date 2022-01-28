using Dapper;
using DBDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBDapper.Repositories
{
    public static class SchemaUSERS
    {
        public static string Table => "users";
        public static string Id => "id";
        public static string FullName => "fullname";
        public static string Phone => "phone";
        public static string Address => "address";
    }

    public class UserRepository: DapperRepository<User>
    {
        public UserRepository(string conn) : base(conn)
        {

        }

        public override void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO {SchemaUSERS.Table} (" +
                    $"{SchemaUSERS.Id}" +
                    $",{SchemaUSERS.FullName}" +
                    $",{SchemaUSERS.Phone}" +
                    $",{SchemaUSERS.Address})" +
                    $" VALUES(" +
                    $"@{nameof(user.id)}" +
                    $",@{nameof(user.fullname)}" +
                    $",@{nameof(user.phone)}" +
                    $",@{nameof(user.address)})";
                db.Execute(sqlQuery, user);
            }
        }

        public IEnumerable<User> GetList(string fullName = "")
        {
            IEnumerable<User> users;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var query = $"SELECT * FROM {SchemaUSERS.Table}";

                if (!string.IsNullOrEmpty(fullName))
                    query = $"{query} WHERE {SchemaUSERS.FullName} LIKE '%{fullName}%'";

                users = db.Query<User>(query).ToList();
            }
            return users;
        }
    }
}
