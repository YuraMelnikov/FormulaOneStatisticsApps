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
    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateManufacturer(Manufacturer manufacturer) =>
            Create(manufacturer);

        public void DeleteManufacturer(Manufacturer manufacturer) =>
            Delete(manufacturer);

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturerAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Manufacturer> GetManufacturerAsync(Guid manufacturerId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(manufacturerId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
