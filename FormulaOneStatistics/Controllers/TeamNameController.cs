using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Collections.Generic;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamNameController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TeamNameController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamName()
        {
            var team = await _repository.TeamName.GetAllTeamNameAsync(trackChanges: false);
            var teamDTO = _mapper.Map<IEnumerable<TeamNameDto>>(team);
            return Ok(teamDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamName(Guid id)
        {
            var team = await _repository.TeamName.GetTeamNameAsync(id, trackChanges: false);
            if (team == null)
                return NotFound();
            else
            {
                var teamDTO = _mapper.Map<TeamNameDto>(team);
                return Ok(teamDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamName([FromBody]TeamNameCreateDto team)
        {
            if (team == null)
                return BadRequest("TeamNameDto object is null.");
            else
            {
                var teamEntity = _mapper.Map<TeamName>(team);
                _repository.TeamName.CreateTeamName(teamEntity);
                await _repository.SaveAsync();
                var teamToReturn = _mapper.Map<TeamNameDto>(teamEntity);
                return CreatedAtRoute("GetTeamName", new { id = teamToReturn.Id }, teamToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamName(Guid id)
        {
            var team = await _repository.TeamName.GetTeamNameAsync(id, trackChanges: false);
            if (team == null)
            {
                return NotFound();
            }
            _repository.TeamName.DeleteTeamName(team);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamName([FromBody] TeamNameDto team)
        {
            if (team == null)
                return BadRequest("TeamNameDto object is null");
            var teamEntity = await _repository.TeamName.GetTeamNameAsync(team.Id, trackChanges: true);
            if (teamEntity == null)
                return NotFound();
            _mapper.Map(team, teamEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}