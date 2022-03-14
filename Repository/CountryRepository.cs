using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateCountry(Country country) =>
            Create(country);

        public void DeleteCountry(Country country) =>
            Delete(country);

        public async Task<IEnumerable<Country>> GetAllCountriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Country> GetCountryAsync(Guid countryId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(countryId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
