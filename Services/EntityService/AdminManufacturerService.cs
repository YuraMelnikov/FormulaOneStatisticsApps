using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    internal class AdminManufacturerService : IAdminManufacturerService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminManufacturerService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(ManufacturerCreateDto manufacturer)
        {
            if (_repositoryContext.Manufacturers.Count(a => a.Name == manufacturer.Name) > 0)
                return false;

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
