using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;

namespace FormulaOneStatistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CountryController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _repository.Country.GetAllCountriesAsync(trackChanges: false);
            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return Ok(countriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(Guid id)
        {
            var country = await _repository.Country.GetCountryAsync(id, trackChanges: false);
            if (country == null)
                return NotFound();
            else
            {
                var countryDTO = _mapper.Map<CountryDto>(country);
                return Ok(countryDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CountryCreateDto country)
        {
            if (country == null)
                return BadRequest("CountryCreateDto object is null.");
            else
            {
                var countryEntity = _mapper.Map<Country>(country);
                _repository.Country.CreateCountry(countryEntity);
                await _repository.SaveAsync();
                var countryToReturn = _mapper.Map<CountryDto>(countryEntity);
                return CreatedAtRoute("GetCountry", new { id = countryToReturn.Id }, countryToReturn);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            var country = await _repository.Country.GetCountryAsync(id, trackChanges: false);
            if (country == null)
            {
                return NotFound();
            }
            _repository.Country.DeleteCountry(country);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryUpdateDto country)
        {
            if (country == null)
                return BadRequest("CountryUpdateDto object is null");
            var countryEntity = await _repository.Country.GetCountryAsync(country.Id, trackChanges: true);
            if (countryEntity == null)
                return NotFound();
            _mapper.Map(country, countryEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}