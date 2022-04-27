using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TrackController(IServiceManager service) =>
            _service = service;

        [HttpGet("configurations/{id}")]
        public async Task<IActionResult> GetConfigurations(Guid id)
        {
            var results = await _service.Track.GetConfigurations(id);
            return Ok(results);
        }

        [HttpGet("images/{id}")]
        public async Task<IActionResult> GetImages(Guid id)
        {
            var results = await _service.Track.GetImages(id);
            return Ok(results);
        }

        [HttpGet("grandprix/{id}")]
        public async Task<IActionResult> GetGrandPrix(Guid id)
        {
            var results = await _service.Track.GetGrandPrix(id);
            return Ok(results);
        }
    }
}
