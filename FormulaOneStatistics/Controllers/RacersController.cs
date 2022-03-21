using Microsoft.AspNetCore.Mvc;
using Repository.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RacersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var racers = await _service.Racers.GetRacersList();
            return Ok(racers);
        }
    }
}
