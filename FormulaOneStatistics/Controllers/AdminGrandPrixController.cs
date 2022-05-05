using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminGrandPrixController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminGrandPrixController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grandPrix = await _service.AdminGrandPrix.Get();
            return Ok(grandPrix);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var grandPrix = await _service.AdminGrandPrix.GetById(id);
            if (grandPrix is null)
                return BadRequest("grandPrix not found.");
            return Ok(grandPrix);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrandPrixDto grandPrix)
        {
            if (grandPrix is null)
                return BadRequest("Create grandPrix object is null.");
            var result = await _service.AdminGrandPrix.Create(grandPrix);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] GrandPrixDto grandPrix)
        {
            if (grandPrix is null)
                return BadRequest("grandPrix object is null");
            var result = await _service.AdminGrandPrix.Update(grandPrix);

            return Ok();
        }
    }
}
