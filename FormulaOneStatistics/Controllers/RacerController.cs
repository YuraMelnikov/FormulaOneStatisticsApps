using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RacerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRacer()
        {
            var racer = await _repository.Racer.GetAllRacerAsync(trackChanges: false);
            var racerDTO = _mapper.Map<IEnumerable<RacerDto>>(racer);
            return Ok(racerDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRacer(Guid id)
        {
            var racer = await _repository.Racer.GetRacerAsync(id, trackChanges: false);
            if (racer == null)
                return NotFound();
            else
            {
                var racerDTO = _mapper.Map<RacerDto>(racer);
                return Ok(racerDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRacer([FromBody]RacerCreateDto racer)
        {
            if (racer == null)
                return BadRequest("RacerDto object is null.");
            else
            {
                var racerEntity = _mapper.Map<Racer>(racer);
                _repository.Racer.CreateRacer(racerEntity);
                await _repository.SaveAsync();
                var racerToReturn = _mapper.Map<RacerDto>(racerEntity);
                return CreatedAtRoute("GetRacer", new { id = racerToReturn.Id }, racerToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRacer(Guid id)
        {
            var racer = await _repository.Racer.GetRacerAsync(id, trackChanges: false);
            if (racer == null)
            {
                return NotFound();
            }
            _repository.Racer.DeleteRacer(racer);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRacer([FromBody] RacerDto racer)
        {
            if (racer == null)
                return BadRequest("RacerDto object is null");
            var racerEntity = await _repository.Racer.GetRacerAsync(racer.Id, trackChanges: true);
            if (racerEntity == null)
                return NotFound();
            _mapper.Map(racer, racerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}