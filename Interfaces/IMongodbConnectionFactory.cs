using MongoDB.Driver;

namespace EmployeeManagement.Interfaces
{
    public interface IMongodbConnectionFactory
    {


        IMongoDatabase GetDatabase();
    }
}
