using Microsoft.AspNetCore.Mvc;
using Repository.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IServiceManager _repository;

        public ManufacturersController(IServiceManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var manufacturers = await _repository.Manufacturers.GetManufacturersList();
            return Ok(manufacturers);
        }
    }
}
