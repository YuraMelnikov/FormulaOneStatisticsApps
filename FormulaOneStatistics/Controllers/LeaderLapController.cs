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
    public class LeaderLapController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LeaderLapController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderLap()
        {
            var leaderLap = await _repository.LeaderLap.GetAllLeaderLapAsync(trackChanges: false);
            var leaderLapDTO = _mapper.Map<IEnumerable<LeaderLapDto>>(leaderLap);
            return Ok(leaderLapDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaderLap(Guid id)
        {
            var leaderLap = await _repository.LeaderLap.GetLeaderLapAsync(id, trackChanges: false);
            if (leaderLap == null)
                return NotFound();
            else
            {
                var leaderLapDTO = _mapper.Map<LeaderLapDto>(leaderLap);
                return Ok(leaderLapDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaderLap([FromBody]LeaderLapCreateDto leaderLap)
        {
            if (leaderLap == null)
                return BadRequest("LeaderLapDto object is null.");
            else
            {
                var leaderLapEntity = _mapper.Map<LeaderLap>(leaderLap);
                _repository.LeaderLap.CreateLeaderLap(leaderLapEntity);
                await _repository.SaveAsync();
                var leaderLapToReturn = _mapper.Map<LeaderLapDto>(leaderLapEntity);
                return CreatedAtRoute("GetLeaderLap", new { id = leaderLapToReturn.Id }, leaderLapToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaderLap(Guid id)
        {
            var leaderLap = await _repository.LeaderLap.GetLeaderLapAsync(id, trackChanges: false);
            if (leaderLap == null)
            {
                return NotFound();
            }
            _repository.LeaderLap.DeleteLeaderLap(leaderLap);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaderLap([FromBody] LeaderLapDto leaderLap)
        {
            if (leaderLap == null)
                return BadRequest("LeaderLapDto object is null");
            var leaderLapEntity = await _repository.LeaderLap.GetLeaderLapAsync(leaderLap.Id, trackChanges: true);
            if (leaderLapEntity == null)
                return NotFound();
            _mapper.Map(leaderLap, leaderLapEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}