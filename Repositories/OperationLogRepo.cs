using EmployeeManagement.Database;
using EmployeeManagement.Interfaces;
using MongoDB.Driver;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Repositories
{
    public class OperationLogRepo:IOperationlogrepo
    {
        private readonly IMongoCollection<LogEntity> _logCollection;
        private readonly IMongodbConnectionFactory _mongodbConnectionFactory;

        public OperationLogRepo(IMongodbConnectionFactory mongoDBConnectionFactory)

        {
            _mongodbConnectionFactory = mongoDBConnectionFactory;
            
            // Get the MongoDB database instance
            var database = _mongodbConnectionFactory.GetDatabase();

            // Access the "Logs" collection
            _logCollection = database.GetCollection<LogEntity>("logs");
        }

        // Method to log an operation
        public async Task LogOperationAsync(LogEntity logEntry)
        {
            logEntry.Timestamp = DateTime.UtcNow; // Ensure the timestamp is set
            await _logCollection.InsertOneAsync(logEntry); // Insert log into MongoDB
        }

        // Method to retrieve all logs from the database
        public async Task<IEnumerable<LogEntity>> GetAllLogsAsync()
        {
            return await _logCollection.Find(_ => true).ToListAsync();
        }
    }

}

