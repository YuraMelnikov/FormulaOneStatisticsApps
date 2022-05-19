using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminChassisController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminChassisController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChassisCreateDto chassis)
        {
            if (chassis is null)
                return BadRequest("Create chassis object is null.");
            var result = await _service.AdminChassis.Create(chassis);

            return Ok(result);
        }
    }
}
