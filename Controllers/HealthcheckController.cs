using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/healthcheck")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        [HttpGet]
        public string Healthcheck() {

            return "API is working, Health 100%";
        }
    }
}
