using EmployeeManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Services;
using EmployeeManagement.Interfaces;
using MongoDB.Bson;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {
        private readonly IAttendenceService _attendanceService;
        private readonly ILogService _logService;

        public AttendenceController(IAttendenceService attendanceService, ILogService logService)
        {
            _attendanceService = attendanceService;
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance([FromBody] AttendanceEntity attendance)
        {
            if (attendance == null)
                return BadRequest();

            var id = await _attendanceService.AddAttendanceAsync(attendance);

            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Post",
                EntityName = "Attendence",
                EntityId = "Att114",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "Added attendene of an employee"
            };

            await _logService.LogOperationAsync(logentry);
            return CreatedAtAction(nameof(GetAttendance), new { id }, attendance);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance(int id)
        {
            var attendance = await _attendanceService.GetAttendanceAsync(id);
            if (attendance == null)
                return NotFound();


            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Get",
                EntityName = "Attendence",
                EntityId = "Att114",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "retrived an attendence details by employee id: " + id.ToString()
            };

            await _logService.LogOperationAsync(logentry);
            return Ok(attendance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendance()
        {
            var attendanceList = await _attendanceService.GetAllAttendanceAsync();

            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Get",
                EntityName = "Attendence",
                EntityId = "Att114",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "retrived the full list of employee attendence"
            };

            await _logService.LogOperationAsync(logentry);
            return Ok(attendanceList);
        }
    }
}
