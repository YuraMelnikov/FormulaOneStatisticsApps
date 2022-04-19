using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RacerController(IServiceManager service) =>
            _service = service;

        [HttpGet("seasons/{id}")]
        public async Task<IActionResult> GetSeasonsResult(Guid id)
        {
            var results = await _service.Racer.GetResultBySeason(id);
            return Ok(results);
        }
    }
}
