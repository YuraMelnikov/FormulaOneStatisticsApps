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

        [HttpGet("calendar/{id}")]
        public async Task<IActionResult> GetCalendar(Guid id)
        {
            var calendar = await _service.Season.GetClendar(id);
            return Ok(calendar);
        }

        [HttpGet("teams/{id}")]
        public async Task<IActionResult> GetTeams(Guid id)
        {
            var teams = await _service.Season.GetPercipient(id);
            return Ok(teams);
        }

        [HttpGet("championshipracers/{id}")]
        public async Task<IActionResult> GetChampionshipResultRacers(Guid id)
        {
            var racersResult = await _service.Season.GetChampionshipRacers(id);
            return Ok(racersResult);
        }

        [HttpGet("championshipteams/{id}")]
        public async Task<IActionResult> GetChampionshipResultTeams(Guid id)
        {
            var teamsResult = await _service.Season.GetChampionshipTeams(id);
            return Ok(teamsResult);
        }
    }
}
