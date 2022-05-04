using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminConstructorsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminConstructorsController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var constructors = await _service.AdminConstructor.Get();
            return Ok(constructors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var constructor = await _service.AdminConstructor.GetById(id);
            if (constructor is null)
                return BadRequest("constructor not found.");
            return Ok(constructor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConstructorDto constructor)
        {
            if (constructor is null)
                return BadRequest("Create constructor object is null.");
            var result = await _service.AdminConstructor.Create(constructor);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ConstructorDto constructor)
        {
            if (constructor is null)
                return BadRequest("ConstructorDto object is null");
            var result = await _service.AdminConstructor.Update(constructor);

            return Ok();
        }
    }
}
