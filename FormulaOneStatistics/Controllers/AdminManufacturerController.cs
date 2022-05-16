using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminManufacturerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminManufacturerController(IServiceManager service) =>
            _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ManufacturerDto manufacturer)
        {
            if (manufacturer is null)
                return BadRequest("Create manufacturer object is null.");
            var result = await _service.AdminManufacturer.Create(manufacturer);

            return Ok(result);
        }
    }
}
