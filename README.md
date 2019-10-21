# core-api-localization

Follow the below steps:

1). Create a folder called 'Resources' and add .resx files to it (eg. EmployeeResource.en-IN.resx). 
    Keep the Access Modifier to 'No code generation'.
    
2). In the Configure() of Startup.cs, add the below code above app.UseMvc();

    // namespace
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.AspNetCore.Localization;

    // code
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-IN"),
        new CultureInfo("en-GB"),
        new CultureInfo("en-US"),
        new CultureInfo("en"),
    };

    app.UseRequestLocalization(options =>
    {
        options.DefaultRequestCulture = new RequestCulture("en-GB");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });
            
3). Create an interface
    
    namespace CoreApiLocalization
    {
        public interface IEmployeeResource
        {
            string Name { get; }
        }
    }
    
4). Create a class that implements the above interface

    using Microsoft.Extensions.Localization;

    namespace CoreApiLocalization
    {
        public class EmployeeResource : IEmployeeResource
        {
            private readonly IStringLocalizer<EmployeeResource> _stringLocalizer;

            public EmployeeResource(IStringLocalizer<EmployeeResource> stringLocalizer)   
            {
                _stringLocalizer = stringLocalizer;
            }

            public string Name => _stringLocalizer["Name"];
        }
    }

5). Add the below controller

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
    
6). Test

    GET       http://localhost:52732/api/Employee
    Headers   Accept-Language:en-IN
    
    Output:   Name in en-IN
    
Done.
    

Done.
