using EmployeeManagement.Config;
using EmployeeManagement.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using Npgsql;

namespace EmployeeManagement.Database
{
    public class DatabaseConnectionFactory:IDatabaseConnectionFactory
    {
        private readonly DatabaseConfig _configuration;
        public DatabaseConnectionFactory(IOptions<DatabaseConfig> config)
        {

            _configuration = config.Value;




        }

       
        public IDbConnection createConnection(string db) {





            if (db == "sql")
            {

                return new SqlConnection(_configuration.SQlServerConnection);
            }
            else if(db=="pgs"){

                return new NpgsqlConnection(_configuration.PostgreSQLConnection);
               




            }

            throw new NotSupportedException("Database type not supported");


        }
            
            
            
            
            
    }
}
