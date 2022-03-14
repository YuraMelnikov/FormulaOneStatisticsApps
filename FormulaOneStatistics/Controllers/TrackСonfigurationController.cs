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
    public class TrackСonfigurationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TrackСonfigurationController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrackСonfiguration()
        {
            var track = await _repository.TrackConfiguration.GetAllTrackСonfigurationAsync(trackChanges: false);
            var trackDTO = _mapper.Map<IEnumerable<TrackСonfigurationDto>>(track);
            return Ok(trackDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackСonfiguration(Guid id)
        {
            var track = await _repository.TrackConfiguration.GetTrackСonfigurationAsync(id, trackChanges: false);
            if (track == null)
                return NotFound();
            else
            {
                var trackDTO = _mapper.Map<TrackСonfigurationDto>(track);
                return Ok(trackDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrackСonfiguration([FromBody]TrackСonfigurationCreateDto track)
        {
            if (track == null)
                return BadRequest("TrackСonfigurationDto object is null.");
            else
            {
                var trackEntity = _mapper.Map<TrackСonfiguration>(track);
                _repository.TrackConfiguration.CreateTrackСonfiguration(trackEntity);
                await _repository.SaveAsync();
                var trackToReturn = _mapper.Map<TrackСonfigurationDto>(trackEntity);
                return CreatedAtRoute("GetTrackСonfiguration", new { id = trackToReturn.Id }, trackToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackСonfiguration(Guid id)
        {
            var track = await _repository.TrackConfiguration.GetTrackСonfigurationAsync(id, trackChanges: false);
            if (track == null)
            {
                return NotFound();
            }
            _repository.TrackConfiguration.DeleteTrackСonfiguration(track);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrackСonfiguration([FromBody] TrackСonfigurationDto track)
        {
            if (track == null)
                return BadRequest("TrackСonfigurationDto object is null");
            var trackEntity = await _repository.TrackConfiguration.GetTrackСonfigurationAsync(track.Id, trackChanges: true);
            if (trackEntity == null)
                return NotFound();
            _mapper.Map(track, trackEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}