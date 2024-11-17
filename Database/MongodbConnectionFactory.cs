using EmployeeManagement.Interfaces;
using MongoDB.Driver;

namespace EmployeeManagement.Database
{
    public class MongodbConnectionFactory:IMongodbConnectionFactory
    {

        private readonly IConfiguration _configuration;
        private readonly MongoClient _client;

        public MongodbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration.GetConnectionString("MongoDB"));
        }

        public IMongoDatabase GetDatabase()
        {
            var databaseName = _configuration["MongoDB:DatabaseName"];
            return _client.GetDatabase(databaseName);
        }
    }
}
