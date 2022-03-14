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
    public class GPController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GPController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGP()
        {
            var gp = await _repository.GP.GetAllGPAsync(trackChanges: false);
            var gpDTO = _mapper.Map<IEnumerable<GPDto>>(gp);
            return Ok(gpDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGP(Guid id)
        {
            var gp = await _repository.GP.GetGPAsync(id, trackChanges: false);
            if (gp == null)
                return NotFound();
            else
            {
                var gpDTO = _mapper.Map<GPDto>(gp);
                return Ok(gpDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGP([FromBody]GPCreateDto gp)
        {
            if (gp == null)
                return BadRequest("GPDto object is null.");
            else
            {
                var gpEntity = _mapper.Map<GrandPrix>(gp);
                _repository.GP.CreateGP(gpEntity);
                await _repository.SaveAsync();
                var gpToReturn = _mapper.Map<GPDto>(gpEntity);
                return CreatedAtRoute("GetGP", new { id = gpToReturn.Id }, gpToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGP(Guid id)
        {
            var gp = await _repository.GP.GetGPAsync(id, trackChanges: false);
            if (gp == null)
            {
                return NotFound();
            }
            _repository.GP.DeleteGP(gp);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGP([FromBody] GPDto gp)
        {
            if (gp == null)
                return BadRequest("GPDto object is null");
            var gpEntity = await _repository.GP.GetGPAsync(gp.Id, trackChanges: true);
            if (gpEntity == null)
                return NotFound();
            _mapper.Map(gp, gpEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}