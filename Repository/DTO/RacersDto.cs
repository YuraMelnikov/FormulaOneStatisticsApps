using AutoMapper;
using Entities.Models;
using Repository.DTO.Common;
using Repository.Mapping;

namespace Repository.DTO
{
    public class RacersDto : CardItemDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Racer, RacersDto>()
                .ForMember(to => to.Name, from => from.MapFrom(x => x.SecondName))
                .ForMember(to => to.ImageLink, from => from.MapFrom(x => x.Image.Link));
        }
    }
}
