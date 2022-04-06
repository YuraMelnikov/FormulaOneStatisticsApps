using AutoMapper;
using Entities.Models;
using Services.DTO.Common;
using Services.Mapping;

namespace Services.DTO
{
    public record RacersDto : CardItemDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Racer, RacersDto>()
                .ForMember(to => to.Name, from => from.MapFrom(x => x.RacerNameEng))
                .ForMember(to => to.ImageLink, from => from.MapFrom(x => x.Image.Link));
        }
    }
}
