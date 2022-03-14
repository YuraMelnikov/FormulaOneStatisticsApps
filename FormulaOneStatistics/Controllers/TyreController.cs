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
    public class TyreController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TyreController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTyre()
        {
            var tyre = await _repository.Tyre.GetAllTyreAsync(trackChanges: false);
            var tyreDTO = _mapper.Map<IEnumerable<TyreDto>>(tyre);
            return Ok(tyreDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTyre(Guid id)
        {
            var tyre = await _repository.Tyre.GetTyreAsync(id, trackChanges: false);
            if (tyre == null)
                return NotFound();
            else
            {
                var tyreDTO = _mapper.Map<TyreDto>(tyre);
                return Ok(tyreDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTyre([FromBody]TyreCreateDto tyre)
        {
            if (tyre == null)
                return BadRequest("TyreDto object is null.");
            else
            {
                var tyreEntity = _mapper.Map<Tyre>(tyre);
                _repository.Tyre.CreateTyre(tyreEntity);
                await _repository.SaveAsync();
                var tyreToReturn = _mapper.Map<TyreDto>(tyreEntity);
                return CreatedAtRoute("GetTyre", new { id = tyreToReturn.Id }, tyreToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTyre(Guid id)
        {
            var tyre = await _repository.Tyre.GetTyreAsync(id, trackChanges: false);
            if (tyre == null)
            {
                return NotFound();
            }
            _repository.Tyre.DeleteTyre(tyre);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTyre([FromBody] TyreDto tyre)
        {
            if (tyre == null)
                return BadRequest("TyreDto object is null");
            var tyreEntity = await _repository.Tyre.GetTyreAsync(tyre.Id, trackChanges: true);
            if (tyreEntity == null)
                return NotFound();
            _mapper.Map(tyre, tyreEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}