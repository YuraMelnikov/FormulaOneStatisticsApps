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
    public class SeasonController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SeasonController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeason()
        {
            var season = await _repository.Season.GetAllSeasonAsync(trackChanges: false);
            var seasonDTO = _mapper.Map<IEnumerable<SeasonDto>>(season);
            return Ok(seasonDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeason(Guid id)
        {
            var season = await _repository.Season.GetSeasonAsync(id, trackChanges: false);
            if (season == null)
                return NotFound();
            else
            {
                var seasonDTO = _mapper.Map<SeasonDto>(season);
                return Ok(seasonDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason([FromBody]SeasonCreateDto season)
        {
            if (season == null)
                return BadRequest("SeasonDto object is null.");
            else
            {
                var seasonEntity = _mapper.Map<Season>(season);
                _repository.Season.CreateSeason(seasonEntity);
                await _repository.SaveAsync();
                var seasonToReturn = _mapper.Map<SeasonDto>(seasonEntity);
                return CreatedAtRoute("GetSeason", new { id = seasonToReturn.Id }, seasonToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(Guid id)
        {
            var season = await _repository.Season.GetSeasonAsync(id, trackChanges: false);
            if (season == null)
            {
                return NotFound();
            }
            _repository.Season.DeleteSeason(season);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeason([FromBody] SeasonDto season)
        {
            if (season == null)
                return BadRequest("SeasonDto object is null");
            var seasonEntity = await _repository.Season.GetSeasonAsync(season.Id, trackChanges: true);
            if (seasonEntity == null)
                return NotFound();
            _mapper.Map(season, seasonEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}