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
    public class TrackController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TrackController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrack()
        {
            var track = await _repository.Track.GetAllTrackAsync(trackChanges: false);
            var trackDTO = _mapper.Map<IEnumerable<TrackDto>>(track);
            return Ok(trackDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrack(Guid id)
        {
            var track = await _repository.Track.GetTrackAsync(id, trackChanges: false);
            if (track == null)
                return NotFound();
            else
            {
                var trackDTO = _mapper.Map<TrackDto>(track);
                return Ok(trackDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrack([FromBody]TrackCreateDto track)
        {
            if (track == null)
                return BadRequest("TrackDto object is null.");
            else
            {
                var trackEntity = _mapper.Map<Track>(track);
                _repository.Track.CreateTrack(trackEntity);
                await _repository.SaveAsync();
                var trackToReturn = _mapper.Map<TrackDto>(trackEntity);
                return CreatedAtRoute("GetTrack", new { id = trackToReturn.Id }, trackToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(Guid id)
        {
            var track = await _repository.Track.GetTrackAsync(id, trackChanges: false);
            if (track == null)
            {
                return NotFound();
            }
            _repository.Track.DeleteTrack(track);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrack([FromBody] TrackDto track)
        {
            if (track == null)
                return BadRequest("TrackDto object is null");
            var trackEntity = await _repository.Track.GetTrackAsync(track.Id, trackChanges: true);
            if (trackEntity == null)
                return NotFound();
            _mapper.Map(track, trackEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}