using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTeamNameController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminTeamNameController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamNameCreateDto teamName)
        {
            if (teamName is null)
                return BadRequest("Create teamName object is null.");
            var result = await _service.AdminTeamName.Create(teamName);

            return Ok(result);
        }
    }
}
