using Microsoft.AspNetCore.Mvc;
using Services.DTOCRUD;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminImagesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminImagesController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var images = await _service.AdminImages.Get();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var image = await _service.AdminImages.GetById(id);
            if (image is null)
                return BadRequest("image not found.");
            return Ok(image);
        }

        [HttpGet("season/{id}")]
        public async Task<IActionResult> GetByIdSeason(Guid id)
        {
            var images = await _service.AdminImages.GetByIdSeason(id);
            if (images is null)
                return BadRequest("image not found.");
            return Ok(images);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImageDto image)
        {
            if (image is null)
                return BadRequest("Create image object is null.");
            var result = await _service.AdminImages.Create(image);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ImageDto image)
        {
            if (image is null)
                return BadRequest("Image object is null");
            var result = await _service.AdminImages.Update(image);

            return Ok(result);
        }
    }
}
