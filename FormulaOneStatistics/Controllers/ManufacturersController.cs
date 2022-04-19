using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ManufacturersController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var manufacturers = await _service.Manufacturers.GetManufacturersList();
            return Ok(manufacturers);
        }
    }
}
