using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructorsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ConstructorsController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var constructors = await _service.Constructors.GetConstructorsList();
            return Ok(constructors);
        }
    }
}
