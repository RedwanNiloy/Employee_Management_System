using EmployeeManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Controllers
{
    [Route("api/log")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService logService;
        public LogController(ILogService serve) 
        
        {
        
        logService = serve; 
        }

        [HttpGet]
        public async Task<IEnumerable<LogEntity>> Get() {

          return await   logService.FetchAllLogsAsync();
        
        
        }  

        
    }
}
