using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminGrandPrixResultController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminGrandPrixResultController(IServiceManager service) =>
            _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.AdminGrandPrixResult.Get(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GrandPrixResultDto result)
        {
            var res = await _service.AdminGrandPrixResult.Update(result);
            return Ok(res);
        }
    }
}
