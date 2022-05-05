using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCountryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminCountryController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var country = await _service.AdminCountry.Get();
            return Ok(country);
        }
    }
}
