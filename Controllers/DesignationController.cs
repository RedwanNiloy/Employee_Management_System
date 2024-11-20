using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

//yo4
//sss
namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _desginationService;
        private readonly ILogService _logService;
        public DesignationController(IDesignationService designationService, ILogService logService)
        {
            _desginationService = designationService;  
            _logService = logService;   
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllDesignation()
        {


            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                EntityName = "Designation",
                OperationType = "Get",
                EntityId = "Desg112",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "retrived all the designation from designation table"
            };

            await _logService.LogOperationAsync(logentry);

            return Ok(await _desginationService.GetAllDesignation());
        }

        [HttpPost("add")]
        public async Task<IActionResult> addDesignation([FromBody] Designation dsg)
        {






            await _desginationService.AddDesignation(dsg);


            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Post",
                EntityName = "Designation",
                EntityId = "desg112",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "added a new designation to database"
            };

            await _logService.LogOperationAsync(logentry);


            return Ok("Designation  added");


        }


        [HttpPost("delete/{id}")]
        public async Task<IActionResult> deleteDesgination(int id)
        {






            await _desginationService.DeleteDesignation(id);


            LogEntity logentry = new LogEntity
            {
                Id = ObjectId.GenerateNewId(),
                OperationType = "Delete",
                EntityName = "Designation",
                EntityId = "Desg111",
                Timestamp = DateTime.UtcNow,
                OperationDetails = "soft deleted of a designation by id: "+id.ToString()
            };

            await _logService.LogOperationAsync(logentry);


            return Ok("Designation deleterd");
        }













    }
}
