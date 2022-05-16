using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ManufacturerController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _service.Manufacturer.Get();
            return Ok(results);
        }
    }
}
