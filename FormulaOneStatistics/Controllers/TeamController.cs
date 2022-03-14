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
    public class TeamController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TeamController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeam()
        {
            var team = await _repository.Team.GetAllTeamAsync(trackChanges: false);
            var teamDTO = _mapper.Map<IEnumerable<TeamDto>>(team);
            return Ok(teamDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(Guid id)
        {
            var team = await _repository.Team.GetTeamAsync(id, trackChanges: false);
            if (team == null)
                return NotFound();
            else
            {
                var teamDTO = _mapper.Map<TeamDto>(team);
                return Ok(teamDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody]TeamCreateDto team)
        {
            if (team == null)
                return BadRequest("TeamDto object is null.");
            else
            {
                var teamEntity = _mapper.Map<Team>(team);
                _repository.Team.CreateTeam(teamEntity);
                await _repository.SaveAsync();
                var teamToReturn = _mapper.Map<TeamDto>(teamEntity);
                return CreatedAtRoute("GetTeam", new { id = teamToReturn.Id }, teamToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            var team = await _repository.Team.GetTeamAsync(id, trackChanges: false);
            if (team == null)
            {
                return NotFound();
            }
            _repository.Team.DeleteTeam(team);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam([FromBody] TeamDto team)
        {
            if (team == null)
                return BadRequest("TeamDto object is null");
            var teamEntity = await _repository.Team.GetTeamAsync(team.Id, trackChanges: true);
            if (teamEntity == null)
                return NotFound();
            _mapper.Map(team, teamEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}