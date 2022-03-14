using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class RacerRepository : RepositoryBase<Racer>, IRacerRepository
    {
        public RacerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateRacer(Racer racer) =>
            Create(racer);

        public void DeleteRacer(Racer racer) =>
            Delete(racer);

        public async Task<IEnumerable<Racer>> GetAllRacerAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.FirstName)
            .ToListAsync();

        public async Task<Racer> GetRacerAsync(Guid racerId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(racerId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
