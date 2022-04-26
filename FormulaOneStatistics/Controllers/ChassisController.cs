using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChassisController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ChassisController(IServiceManager service) =>
            _service = service;

        [HttpGet("seasons/{id}")]
        public async Task<IActionResult> GetList(Guid id)
        {
            var results = await _service.Chassis.GetList(id);
            return Ok(results);
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetInfo(Guid id)
        {
            var results = await _service.Chassis.GetInfo(id);
            return Ok(results);
        }

        [HttpGet("images/{id}")]
        public async Task<IActionResult> GetImages(Guid id)
        {
            var results = await _service.Chassis.GetImages(id);
            return Ok(results);
        }

        [HttpGet("classifications/{id}")]
        public async Task<IActionResult> GetClassifications(Guid id)
        {
            var results = await _service.Chassis.GetClassification(id);
            return Ok(results);
        }
    }
}
