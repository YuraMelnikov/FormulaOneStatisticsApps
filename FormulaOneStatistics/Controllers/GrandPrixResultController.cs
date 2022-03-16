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
    public class GrandPrixResultController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GrandPrixResultController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGPResult()
        {
            var gp = await _repository.GPResult.GetAllGPResultAsync(trackChanges: false);
            var gpDTO = _mapper.Map<IEnumerable<GPResultDto>>(gp);
            return Ok(gpDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGPResult(Guid id)
        {
            var gp = await _repository.GPResult.GetGPResultAsync(id, trackChanges: false);
            if (gp == null)
                return NotFound();
            else
            {
                var gpDTO = _mapper.Map<GPResultDto>(gp);
                return Ok(gpDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGPResult([FromBody]GPResultCreateDto gp)
        {
            if (gp == null)
                return BadRequest("GPResultDto object is null.");
            else
            {
                var gpEntity = _mapper.Map<GrandPrixResult>(gp);
                _repository.GPResult.CreateGPResult(gpEntity);
                await _repository.SaveAsync();
                var gpToReturn = _mapper.Map<GPResultDto>(gpEntity);
                return CreatedAtRoute("GetGPResult", new { id = gpToReturn.Id }, gpToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGPResult(Guid id)
        {
            var gp = await _repository.GPResult.GetGPResultAsync(id, trackChanges: false);
            if (gp == null)
            {
                return NotFound();
            }
            _repository.GPResult.DeleteGPResult(gp);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGPResult([FromBody] GPResultDto gp)
        {
            if (gp == null)
                return BadRequest("GPResultDto object is null");
            var gpEntity = await _repository.GPResult.GetGPResultAsync(gp.Id, trackChanges: true);
            if (gpEntity == null)
                return NotFound();
            _mapper.Map(gp, gpEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}