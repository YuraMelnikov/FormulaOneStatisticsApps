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
    public class FastLapController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FastLapController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFastLap()
        {
            var fastLap = await _repository.FastLap.GetAllFastLapAsync(trackChanges: false);
            var fastLapDTO = _mapper.Map<IEnumerable<FastLapDto>>(fastLap);
            return Ok(fastLapDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFastLap(Guid id)
        {
            var fastLap = await _repository.FastLap.GetFastLapAsync(id, trackChanges: false);
            if (fastLap == null)
                return NotFound();
            else
            {
                var fastLapDTO = _mapper.Map<FastLapDto>(fastLap);
                return Ok(fastLapDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFastLap([FromBody]FastLapCreateDto fastLap)
        {
            if (fastLap == null)
                return BadRequest("FastLapCreateDto object is null.");
            else
            {
                var fastLapEntity = _mapper.Map<FastLap>(fastLap);
                _repository.FastLap.CreateFastLap(fastLapEntity);
                await _repository.SaveAsync();
                var fastLapToReturn = _mapper.Map<FastLapDto>(fastLapEntity);
                return CreatedAtRoute("GetFastLap", new { id = fastLapToReturn.Id }, fastLapToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFastLap(Guid id)
        {
            var fastLap = await _repository.FastLap.GetFastLapAsync(id, trackChanges: false);
            if (fastLap == null)
            {
                return NotFound();
            }
            _repository.FastLap.DeleteFastLap(fastLap);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFastLap([FromBody] FastLapUpdateDto fastLap)
        {
            if (fastLap == null)
                return BadRequest("FastLapUpdateDto object is null");
            var fastLapEntity = await _repository.FastLap.GetFastLapAsync(fastLap.Id, trackChanges: true);
            if (fastLapEntity == null)
                return NotFound();
            _mapper.Map(fastLap, fastLapEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}