using AutoMapper;
using Entities.Contexts;
using Entities.Models;
using Services.DTO;
using Services.IEntityService;
using Services.Service;

namespace Services.EntityService
{
    public class SeasonService : ServiceBase<Season, SeasonCreateDto>, ISeasonService
    {
        public SeasonService(RepositoryContext repositoryContext, IMapper mapper) 
            : base(repositoryContext, mapper)
        {
        }

        //public void CreateSeason(SeasonCreateDto season) 
        //{
        //    var countYear = _repositoryContext.Seasons.Count(a => a.Year == season.Year);
        //    if(countYear > 0 | season is null)
        //        return throw new Exception.
        //    if(season.)
        //    Add(season);
        //}
            

        public void DeleteSeason(Guid id) =>
            Delete(id);
    }
}
