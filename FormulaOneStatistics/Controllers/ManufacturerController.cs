using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ManufacturerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetManufacturer()
        {
            var manufacturer = await _repository.Manufacturer.GetAllManufacturerAsync(trackChanges: false);
            var manufacturerDTO = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturer);
            return Ok(manufacturerDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturer(Guid id)
        {
            var manufacturer = await _repository.Manufacturer.GetManufacturerAsync(id, trackChanges: false);
            if (manufacturer == null)
                return NotFound();
            else
            {
                var manufacturerDTO = _mapper.Map<ManufacturerDto>(manufacturer);
                return Ok(manufacturerDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromBody]ManufacturerCreateDto manufacturer)
        {
            if (manufacturer == null)
                return BadRequest("ManufacturerDto object is null.");
            else
            {
                var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturer);
                _repository.Manufacturer.CreateManufacturer(manufacturerEntity);
                await _repository.SaveAsync();
                var manufacturerToReturn = _mapper.Map<ManufacturerDto>(manufacturerEntity);
                return CreatedAtRoute("GetManufacturer", new { id = manufacturerToReturn.Id }, manufacturerToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(Guid id)
        {
            var manufacturer = await _repository.Manufacturer.GetManufacturerAsync(id, trackChanges: false);
            if (manufacturer == null)
            {
                return NotFound();
            }
            _repository.Manufacturer.DeleteManufacturer(manufacturer);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManufacturer([FromBody] ManufacturerDto manufacturer)
        {
            if (manufacturer == null)
                return BadRequest("ManufacturerDto object is null");
            var manufacturerEntity = await _repository.Manufacturer.GetManufacturerAsync(manufacturer.Id, trackChanges: true);
            if (manufacturerEntity == null)
                return NotFound();
            _mapper.Map(manufacturer, manufacturerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}