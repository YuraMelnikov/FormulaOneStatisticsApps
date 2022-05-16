using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    internal class AdminManufacturer : IAdminManufacturer
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminManufacturer(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(ManufacturerDto manufacturer)
        {
            var newManufacturer = new Manufacturer
            {
                IdCountry = manufacturer.IdCountry,
                Name = manufacturer.Name,
                IdImage = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id
            };
            _repositoryContext.Add(newManufacturer);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
