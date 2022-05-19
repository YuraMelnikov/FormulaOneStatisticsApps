using Entities.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.DTOCRUD;
using Services.IEntityService;

namespace Services.EntityService
{
    public class AdminChassisService : IAdminChassisService
    {
        private readonly RepositoryContext _repositoryContext;

        public AdminChassisService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<bool> Create(ChassisCreateDto chassis)
        {
            if (_repositoryContext.Chassis.AsNoTracking().Count(a => a.Name == chassis.Name) > 0)
                return false;

            var newChassis = new Chassis
            {
                IdManufacturer = chassis.IdManufacturer,
                Name = chassis.Name,
                IdImage = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id,
                IdLivery = _repositoryContext.Images.AsNoTracking().FirstOrDefault(a => a.Link == DefaulValues.DefaultImage).Id,
            };
            _repositoryContext.Add(newChassis);
            await _repositoryContext.SaveChangesAsync();

            return true;
        }
    }
}
