using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.IEntityService;

namespace Services.EntityService
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly RepositoryContext _repositoryContext;

        public ManufacturerService(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public async Task<IEnumerable<ManufacturerDto>> GetChassis(Guid manufacturerId)
        {
            var query = await _repositoryContext.Participants
                 .AsNoTracking()
                 .Where(a => a.IdChassis == chassisId)
                 .OrderBy(a => a.GrandPrix.Season.Year)
                 .Select(a => new
                 {
                     IdSeason = a.GrandPrix.IdSeason,
                     Season = a.GrandPrix.Season.Year,
                     Team = a.Team.Name,
                     IdDriver = a.IdRacer,
                     Driver = a.Racer.RacerNameEng,
                     IdEngine = a.IdEngine,
                     Engine = a.Engine.Name,
                     IdTyre = a.IdTyre,
                     Tyre = a.Tyre.Name
                 })
                 .Distinct()
                 .ToArrayAsync();

            var result = new ChassisListDto
            {
                Seasons = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdSeason,
                    Name = a.Season.ToString()
                }).Distinct(),
                Drivers = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdDriver,
                    Name = a.Driver
                }).Distinct(),
                Engines = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdEngine,
                    Name = a.Engine
                }).Distinct(),
                Tyres = query.Select(a => new LabelItemWhisId
                {
                    Id = a.IdTyre,
                    Name = a.Tyre
                }).Distinct(),
            };

            return result;


            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManufacturerDto>> GetEngines(Guid manufacturerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ManufacturerDto>> GetTyres(Guid manufacturerId)
        {
            throw new NotImplementedException();
        }
    }
}
