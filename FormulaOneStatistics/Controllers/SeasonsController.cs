using Microsoft.AspNetCore.Mvc;
using Repository.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly IServiceManager _repository;

        public SeasonsController(IServiceManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seasons = await _repository.Seasons.GetSeasonsList();
            return Ok(seasons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestRes()
        {
            var seasons = new List<int> { 1, 2, 3, 4, 5 };
            return Ok(seasons);
        }
    }
}