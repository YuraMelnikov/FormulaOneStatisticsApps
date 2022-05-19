using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEngineController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminEngineController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EngineCreateDto engine)
        {
            if (engine is null)
                return BadRequest("Create engine object is null.");
            var result = await _service.AdminEngine.Create(engine);

            return Ok(result);
        }
    }
}
