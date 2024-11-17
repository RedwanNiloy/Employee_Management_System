
using EmployeeManagement.Entities;
namespace EmployeeManagement.Interfaces
{
    public interface ILogService
    {
        Task<IEnumerable<LogEntity>> FetchAllLogsAsync();
        Task LogOperationAsync(LogEntity logEntry);

    }
}
