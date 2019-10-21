using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiLocalization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeResource _employeeResource;

        public EmployeeController(IEmployeeResource sharedResource)
        {
            _employeeResource = sharedResource;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_employeeResource.Name);
        }
    }
}