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
    public static class SchemaEMPLOYEE
    {
        public static string Table => "EMPLOYEE";
        public static string Id => "EMP_ID";
        public static string LastName => "LAST_NAME";
        public static string FirstName => "FIRST_NAME";
        public static string Title => "TITLE";
        public static string StartDate => "START_DATE";
    }

    public class EmployeeRepository: DapperRepository<Employee>
    {
        public EmployeeRepository(string conn): base(conn)
        {

        }

        public override void Create(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO {SchemaEMPLOYEE.Table} (" +
                    $"{SchemaEMPLOYEE.Id}" +
                    $",{SchemaEMPLOYEE.LastName}" +
                    $",{SchemaEMPLOYEE.FirstName}" +
                    $",{SchemaEMPLOYEE.Title}" +
                    $" VALUES(" +
                    $"@{nameof(employee.EMP_ID)}" +
                    $",@{nameof(employee.LAST_NAME)}" +
                    $",@{nameof(employee.FIRST_NAME)}" +
                    $",@{nameof(employee.TITLE)})";
                db.Execute(sqlQuery, employee);
            }
        }
        public override void Delete(int id)
        {

        }
        public override Employee Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Employee>($"SELECT * FROM {SchemaEMPLOYEE.Table} WHERE {SchemaEMPLOYEE.Id} = @id", new { id }).FirstOrDefault();
            }
        }
        public override IEnumerable<Employee> GetList()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Employee>($"SELECT * FROM {SchemaEMPLOYEE.Table}").ToList();
            }
        }
        public override void Update(Employee user)
        {

        }
    }
}
