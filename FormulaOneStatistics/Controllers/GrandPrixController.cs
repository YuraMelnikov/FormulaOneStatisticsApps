using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrandPrixController : ControllerBase
    {
        private readonly IServiceManager _service;

        public GrandPrixController(IServiceManager service) =>
            _service = service;

        [HttpGet("participants/{id}")]
        public async Task<IActionResult> GetParticipants(Guid id)
        {
            var participants = await _service.GrandPrixResult.GetParticipant(id);
            return Ok(participants);
        }

        [HttpGet("qualification/{id}")]
        public async Task<IActionResult> GetQualification(Guid id)
        {
            var qualification = await _service.GrandPrixResult.GetQualification(id);
            return Ok(qualification);
        }

        [HttpGet("classification/{id}")]
        public async Task<IActionResult> GetClassification(Guid id)
        {
            var classification = await _service.GrandPrixResult.GetClassification(id);
            return Ok(classification);
        }

        [HttpGet("leaderLap/{id}")]
        public async Task<IActionResult> GetLeaderLap(Guid id)
        {
            var images = await _service.GrandPrixResult.GetLeaderLap(id);
            return Ok(images);
        }

        [HttpGet("images/{id}")]
        public async Task<IActionResult> GetImages(Guid id)
        {
            var images = await _service.GrandPrixResult.GetImages(id);
            return Ok(images);
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetInfo(Guid id)
        {
            var info = await _service.GrandPrixResult.GetInfo(id);
            return Ok(info);
        }

        [HttpGet("fastLap/{id}")]
        public async Task<IActionResult> GetFastLap(Guid id)
        {
            var fastLap = await _service.GrandPrixResult.GetFastLap(id);
            return Ok(fastLap);
        }

        [HttpGet("champracers/{id}")]
        public async Task<IActionResult> GetChampRacers(Guid id)
        {
            var state = await _service.GrandPrixResult.GetChampRacers(id);
            return Ok(state);
        }

        [HttpGet("champconstructors/{id}")]
        public async Task<IActionResult> GetChampConstructors(Guid id)
        {
            var state = await _service.GrandPrixResult.GetChampConstructors(id);
            return Ok(state);
        }
    }
}
