using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminGrandPrixNamesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminGrandPrixNamesController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrandPrixNamesCreateDto name)
        {
            if (name is null)
                return BadRequest("Create name object is null.");
            var result = await _service.AdminGrandPrixNames.Create(name);

            return Ok(result);
        }
    }
}
