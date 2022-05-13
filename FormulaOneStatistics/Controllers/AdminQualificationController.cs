using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminQualificationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminQualificationController(IServiceManager service) =>
            _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.AdminQualification.Get(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] QualificationDto qualification)
        {
            var result = await _service.AdminQualification.Update(qualification);
            return Ok(result);
        }
    }
}
