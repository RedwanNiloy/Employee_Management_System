using System.Data;

namespace EmployeeManagement.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
       IDbConnection createConnection(string db);
    }
}
