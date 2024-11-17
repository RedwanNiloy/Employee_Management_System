using MongoDB.Bson;

namespace EmployeeManagement.Entities
{
    public class LogEntity
    {
        public ObjectId Id { get; set; } 
        public string OperationType { get; set; }
        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public DateTime Timestamp { get; set; }
        public string OperationDetails { get; set; }
    }
}
