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

        [HttpGet("chassis/{id}")]
        public async Task<IActionResult> GetChassis(Guid id)
        {
            var results = await _service.Manufacturer.GetChassis(id);
            return Ok(results);
        }

        [HttpGet("engines/{id}")]
        public async Task<IActionResult> GetEngines(Guid id)
        {
            var results = await _service.Manufacturer.GetEngines(id);
            return Ok(results);
        }

        [HttpGet("tyres/{id}")]
        public async Task<IActionResult> GetTyres(Guid id)
        {
            var results = await _service.Manufacturer.GetTyres(id);
            return Ok(results);
        }
    }
}
