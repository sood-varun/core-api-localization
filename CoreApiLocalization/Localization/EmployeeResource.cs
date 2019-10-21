using Microsoft.Extensions.Localization;

namespace CoreApiLocalization
{
    public class EmployeeResource : IEmployeeResource
    {
        private readonly IStringLocalizer<EmployeeResource> _stringLocalizer;

        public EmployeeResource(IStringLocalizer<EmployeeResource> localizer)   
        {
            _stringLocalizer = localizer;
        }

        public string Name => _stringLocalizer["Name"];
    }
}