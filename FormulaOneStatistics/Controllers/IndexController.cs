using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IServiceManager _service;

        public IndexController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> GetLastResult()
        {
            var lastResult = await _service.GrandPrixResult.GetLastResult();
            return Ok(lastResult);
        }
    }
}
