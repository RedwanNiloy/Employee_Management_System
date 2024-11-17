
using EmployeeManagement.Entities;
namespace EmployeeManagement.Interfaces
{
    public interface IOperationlogrepo
    {
        Task LogOperationAsync(LogEntity logEntry); // Existing method to log an operation
        Task<IEnumerable<LogEntity>> GetAllLogsAsync();
    }
}
