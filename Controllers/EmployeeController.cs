using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;

namespace EmployeeManagement.Controllers
{ 
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogService _logService;
        public EmployeeController(IEmployeeService employeeService, ILogService serve) {

            _employeeService = employeeService;
            _logService = serve;    



        }

        [HttpGet("GetAll")]
        public  async Task<IActionResult> getAllEmployee() {



            
              var emp=  await _employeeService.GetAllEmployees();
              
              LogEntity logentry= new LogEntity
              {
                  Id = ObjectId.GenerateNewId(),
                  OperationType= "Get",
                  EntityName = "Employee",
                  EntityId = "Emp111",
                  Timestamp = DateTime.UtcNow,  
                  OperationDetails = "retrived all the employee details from employee table"
              };

             await _logService.LogOperationAsync(logentry);






            return Ok(emp);
            



            

        
        
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> getById(int id)
        {




            var emp = await _employeeService.GetEmployeeById(id);

            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "GetById",
                EntityName = "Employee",
                EntityId = "Emp111",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "retrived employee details by id :" + id.ToString()
            };

            await _logService.LogOperationAsync(logentry);




            return Ok(emp);








        }


        [HttpPost("add")]
        public async Task<IActionResult> addEmployee([FromBody] EmployeeEntity employee)
        {




            var emp = await _employeeService.AddEmployee(employee);
            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Post",
                EntityName = "Employee",
                EntityId = "Emp111",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "Added a new employee"
            };

            await _logService.LogOperationAsync(logentry);



            return Ok(emp);








        }


        [HttpPost("/delete/{id}")]
        public async Task<IActionResult> deleteEmployee(int id)
        {




            await _employeeService.DeleteEmployee(id);
            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Delete",
                EntityName = "Employee",
                EntityId = "Emp111",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "soft deleted of an employee by id :"+ id.ToString() 
            };

            await _logService.LogOperationAsync(logentry);




            return Ok("Deleted");








        }


    }
}
