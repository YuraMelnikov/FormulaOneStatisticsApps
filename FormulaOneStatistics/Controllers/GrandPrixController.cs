using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrandPrixController : ControllerBase
    {
        private readonly IServiceManager _service;

        public GrandPrixController(IServiceManager service)
        {
            _service = service;
        }

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
    }
}
