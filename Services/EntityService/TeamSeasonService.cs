using AutoMapper;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Common;
using Services.IEntityService;

namespace Services.EntityService
{
    public class TeamSeasonService : ITeamSeasonService
    {
        private readonly RepositoryContext _repositoryContext;

        public TeamSeasonService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetChassisTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdChassis)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var chassies = await query.ToListAsync();

            foreach (var chassi in chassies)
                chassi.Name = _repositoryContext.Chassis.Find(chassi.Id).Name;

            return chassies;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetEngineTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdEngine)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var engines = await query.ToListAsync();

            foreach (var engine in engines)
                engine.Name = _repositoryContext.Engines.Find(engine.Id).Name;

            return engines;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetRacersTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdRacer)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var racers = await query.ToListAsync();

            foreach (var racer in racers)
                racer.Name = _repositoryContext.Racers.Find(racer.Id).SecondName;

            return racers;
        }

        public async Task<IEnumerable<LabelItemWhisId>> GetTyreTeamOnSeason(Guid idSeason, Guid idTeam)
        {
            var query = _repositoryContext.Participants
                .AsNoTracking()
                .Where(a => a.IdTeam == idTeam && a.GrandPrix.IdSeason == idSeason)
                .GroupBy(x => x.IdTyre)
                .Select(a => new LabelItemWhisId { Id = a.Key });
            var tyres = await query.ToListAsync();

            foreach(var tyre in tyres)
                tyre.Name = _repositoryContext.Tyres.Find(tyre.Id).Name;

            return tyres;
        }
    }
}