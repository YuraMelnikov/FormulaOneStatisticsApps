using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTrackConfigurationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminTrackConfigurationController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrackConfigurationCreateDto config)
        {
            if (config is null)
                return BadRequest("Create config object is null.");
            var result = await _service.AdminTrackConfiguration.Create(config);

            return Ok(result);
        }
    }
}
