using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSeasonController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminSeasonController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var seasons = await _service.AdminSeason.Get();
            return Ok(seasons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var season = await _service.AdminSeason.GetById(id);
            if (season is null)
                return BadRequest("season not found.");
            return Ok(season);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeasonDto season)
        {
            if (season is null)
                return BadRequest("Create season object is null.");
            var result = await _service.AdminSeason.Create(season);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SeasonDto season)
        {
            if (season is null)
                return BadRequest("SeasonUpdateDto object is null");
            var result = await _service.AdminSeason.Update(season);

            return Ok();
        }
    }
}
