using Microsoft.AspNetCore.Mvc;
using Repository.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacersController : ControllerBase
    {
        private readonly IServiceManager _repository;

        public RacersController(IServiceManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var racers = await _repository.Racers.GetRacersList();
            return Ok(racers);
        }
    }
}
