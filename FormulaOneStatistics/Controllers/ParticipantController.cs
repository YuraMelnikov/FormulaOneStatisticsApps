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
    public class ParticipantController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ParticipantController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetParticipant()
        {
            var participant = await _repository.Participant.GetAllParticipantAsync(trackChanges: false);
            var participantDTO = _mapper.Map<IEnumerable<ParticipantDto>>(participant);
            return Ok(participantDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipant(Guid id)
        {
            var participant = await _repository.Participant.GetParticipantAsync(id, trackChanges: false);
            if (participant == null)
                return NotFound();
            else
            {
                var participantDTO = _mapper.Map<ParticipantDto>(participant);
                return Ok(participantDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant([FromBody]ParticipantCreateDto participant)
        {
            if (participant == null)
                return BadRequest("ParticipantDto object is null.");
            else
            {
                var participantEntity = _mapper.Map<Participant>(participant);
                _repository.Participant.CreateParticipant(participantEntity);
                await _repository.SaveAsync();
                var participantToReturn = _mapper.Map<ParticipantDto>(participantEntity);
                return CreatedAtRoute("GetParticipant", new { id = participantToReturn.Id }, participantToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(Guid id)
        {
            var participant = await _repository.Participant.GetParticipantAsync(id, trackChanges: false);
            if (participant == null)
            {
                return NotFound();
            }
            _repository.Participant.DeleteParticipant(participant);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant([FromBody] ParticipantDto participant)
        {
            if (participant == null)
                return BadRequest("ParticipantDto object is null");
            var participantEntity = await _repository.Participant.GetParticipantAsync(participant.Id, trackChanges: true);
            if (participantEntity == null)
                return NotFound();
            _mapper.Map(participant, participantEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}