using System;
using Contracts;
using AutoMapper;
using Entities.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entities.DataTransferObjects;


namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChassiController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ChassiController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetChassis()
        {
            var chassies = await _repository.Chassi.GetAllChassisAsync(trackChanges: false);
            var chassiesDto = _mapper.Map<IEnumerable<ChassiDto>>(chassies);
            return Ok(chassiesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChassi(Guid id)
        {
            var chassi = await _repository.Chassi.GetChassiAsync(id, trackChanges: false);
            if (chassi == null)
                return NotFound();
            else
            {
                var chassiDTO = _mapper.Map<ChassiDto>(chassi);
                return Ok(chassiDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateChassi([FromBody]ChassiCreateDto chassi)
        {
            if (chassi == null)
                return BadRequest("ChassiCreateDto object is null.");
            else
            {
                var chassiEntity = _mapper.Map<Chassis>(chassi);
                _repository.Chassi.CreateChassi(chassiEntity);
                await _repository.SaveAsync();
                var chassiToReturn = _mapper.Map<ChassiDto>(chassiEntity);
                return CreatedAtRoute("GetChassi", new { id = chassiToReturn.Id }, chassiToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChassi(Guid id)
        {
            var chassi = await _repository.Chassi.GetChassiAsync(id, trackChanges: false);
            if (chassi == null)
            {
                return NotFound();
            }
            _repository.Chassi.DeleteChassi(chassi);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChassi([FromBody] ChassiUpdateDto chassi)
        {
            if (chassi == null)
                return BadRequest("ChassiUpdateDto object is null");
            var chassiEntity = await _repository.Chassi.GetChassiAsync(chassi.Id, trackChanges: true);
            if (chassiEntity == null)
                return NotFound();
            _mapper.Map(chassi, chassiEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}