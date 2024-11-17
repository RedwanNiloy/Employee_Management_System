using EmployeeManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Entities;
using MongoDB.Bson;
namespace EmployeeManagement.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {


        private readonly IDepartmentService _departmentService;
        private readonly ILogService _logService;
         public DepartmentController(IDepartmentService departmentService, ILogService logService)
        {
            _departmentService = departmentService;
            _logService = logService;   
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllDepartment()
        {

            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Get",
                EntityName = "Department",
                EntityId = "Dept113",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "retrived all the department details from department table"
            };

            await _logService.LogOperationAsync(logentry);


            return Ok(await _departmentService.GetAllDepartment());
}



        [HttpPost("add")]
        public async Task<IActionResult> addDept( [FromBody] Department dept)
        {






            await _departmentService.AddDepartment(dept);

            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Post",
                EntityName = "Department",
                EntityId = "Dept113",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "added a new department named: "+dept.name
            };

            await _logService.LogOperationAsync(logentry);


            return Ok("Department added");
                
                
                }


        [HttpPost("delete/{id}")]
        public async Task<IActionResult> deleteDept(int id)
        {






            await _departmentService.DeleteDepartment(id);

            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Delete",
                EntityName = "Department",
                EntityId = "Dept113",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "Soft delete of a dept by id :"+ id.ToString()
            };

            await _logService.LogOperationAsync(logentry);


            return Ok("Department Deleted");
         }




    }
}
