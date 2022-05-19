using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTeamController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminTeamController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamCreateDto team)
        {
            if (team is null)
                return BadRequest("Create team object is null.");
            var result = await _service.AdminTeam.Create(team);

            return Ok(result);
        }
    }
}
