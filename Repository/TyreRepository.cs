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
    public class TyreRepository : RepositoryBase<Tyre>, ITyreRepository
    {
        public TyreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTyre(Tyre tyre) =>
            Create(tyre);

        public void DeleteTyre(Tyre tyre) =>
            Delete(tyre);

        public async Task<IEnumerable<Tyre>> GetAllTyreAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Tyre> GetTyreAsync(Guid tyreId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(tyreId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
