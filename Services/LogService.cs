using EmployeeManagement.Interfaces;
using EmployeeManagement.Repositories;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    public class LogService:ILogService
    {
        private readonly IOperationlogrepo _logRepository;

        public LogService(IOperationlogrepo logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<LogEntity>> FetchAllLogsAsync()
        {
            return await _logRepository.GetAllLogsAsync();
        }

        public async Task LogOperationAsync(LogEntity logEntry) { 
        
        
         await _logRepository.LogOperationAsync(logEntry);   
            
        }
    }
}
