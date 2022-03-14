using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EngineController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEngines()
        {
            var engine = await _repository.Engine.GetAllEngineAsync(trackChanges: false);
            var engineDTO = _mapper.Map<IEnumerable<EngineDto>>(engine);
            return Ok(engineDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEngine(Guid id)
        {
            var engine = await _repository.Engine.GetEngineAsync(id, trackChanges: false);
            if (engine == null)
                return NotFound();
            else
            {
                var engineDTO = _mapper.Map<EngineDto>(engine);
                return Ok(engineDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEngine([FromBody]EngineCreateDto engine)
        {
            if (engine == null)
                return BadRequest("EngineCreateDto object is null.");
            else
            {
                var engineEntity = _mapper.Map<Engine>(engine);
                _repository.Engine.CreateEngine(engineEntity);
                await _repository.SaveAsync();
                var dnqToReturn = _mapper.Map<EngineDto>(engineEntity);
                return CreatedAtRoute("GetDNQ", new { id = dnqToReturn.Id }, dnqToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEngine(Guid id)
        {
            var engine = await _repository.Engine.GetEngineAsync(id, trackChanges: false);
            if (engine == null)
            {
                return NotFound();
            }
            _repository.Engine.DeleteEngine(engine);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEngine([FromBody] EngineUpdateDto engine)
        {
            if (engine == null)
                return BadRequest("EngineUpdateDto object is null");
            var engineEntity = await _repository.Engine.GetEngineAsync(engine.Id, trackChanges: true);
            if (engineEntity == null)
                return NotFound();
            _mapper.Map(engine, engineEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}