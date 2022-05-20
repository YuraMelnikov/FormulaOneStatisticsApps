using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTrackController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminTrackController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrackCreateDto track)
        {
            if (track is null)
                return BadRequest("Create track object is null.");
            var result = await _service.AdminTrack.Create(track);

            return Ok(result);
        }
    }
}
