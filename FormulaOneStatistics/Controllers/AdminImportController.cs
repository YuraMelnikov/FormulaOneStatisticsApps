using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminImportController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminImportController(IServiceManager service) =>
            _service = service;

        [HttpPost("save")]
        public async Task<IActionResult> Save(IFormFile file)
        {
            var result = _service.AdminImport.ImportData(file);
            return Ok(result);
        }
    }
}
