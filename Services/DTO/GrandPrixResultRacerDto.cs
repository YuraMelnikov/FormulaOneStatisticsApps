using AutoMapper;
using Entities.Models;
using Services.Mapping;

namespace Services.DTO
{
    public record GrandPrixResultRacerDto : IMapFrom
    {
        public string RacePosition { get; set; }
        public float Point { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GrandPrixResult, GrandPrixResultRacerDto>()
                .ForMember(to => to.RacePosition, from => from.MapFrom(x => x.Classification))
                .ForMember(to => to.Point, from => from.MapFrom(x => x.Points));
        }
    }
}
