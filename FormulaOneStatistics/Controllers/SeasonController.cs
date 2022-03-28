using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SeasonController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendar(Guid id)
        {
            var calendar = await _service.Season.GetClendarSeason(id);
            return Ok(calendar);
        }
    }
}
