using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using OrderSystem.AuthService.Entities;

namespace OrderSystem.AuthService.DAL
{
    public class UserAccess : IUserAccess
    {
        private readonly string _connectionString;

        public UserAccess()
        {
            _connectionString = new Connection().Local;
        }

        public User GetUserWithId(int id)
        {
            const string query = "Select * from dbo.Users where [Id] = @Id";

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    var result = con.Query<User>(query, new { Id = id });
                    return result.First();
                }
                catch
                {
                    throw new Exception("Unexpected Database Error");
                }
            }


        }
    }
}
