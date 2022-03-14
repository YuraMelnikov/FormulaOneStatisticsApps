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
    public class QualificationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public QualificationController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQualification()
        {
            var qualification = await _repository.Qualification.GetAllQualificationAsync(trackChanges: false);
            var qualificationDTO = _mapper.Map<IEnumerable<QualificationDto>>(qualification);
            return Ok(qualificationDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQualification(Guid id)
        {
            var qualification = await _repository.Qualification.GetQualificationAsync(id, trackChanges: false);
            if (qualification == null)
                return NotFound();
            else
            {
                var qualificationDTO = _mapper.Map<QualificationDto>(qualification);
                return Ok(qualificationDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateQualification([FromBody]QualificationCreateDto qualification)
        {
            if (qualification == null)
                return BadRequest("QualificationDto object is null.");
            else
            {
                var qualificationEntity = _mapper.Map<Qualification>(qualification);
                _repository.Qualification.CreateQualification(qualificationEntity);
                await _repository.SaveAsync();
                var qualificationToReturn = _mapper.Map<QualificationDto>(qualificationEntity);
                return CreatedAtRoute("GetQualification", new { id = qualificationToReturn.Id }, qualificationToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualification(Guid id)
        {
            var qualification = await _repository.Qualification.GetQualificationAsync(id, trackChanges: false);
            if (qualification == null)
            {
                return NotFound();
            }
            _repository.Qualification.DeleteQualification(qualification);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQualification([FromBody] QualificationDto qualification)
        {
            if (qualification == null)
                return BadRequest("QualificationDto object is null");
            var qualificationEntity = await _repository.Qualification.GetQualificationAsync(qualification.Id, trackChanges: true);
            if (qualificationEntity == null)
                return NotFound();
            _mapper.Map(qualification, qualificationEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}