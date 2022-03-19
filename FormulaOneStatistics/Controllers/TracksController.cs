using Microsoft.AspNetCore.Mvc;
using Repository.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IServiceManager _repository;

        public TracksController(IServiceManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tracks = await _repository.Tracks.GetTracksList();
            return Ok(tracks);
        }
    }
}