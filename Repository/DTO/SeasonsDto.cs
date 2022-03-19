using AutoMapper;
using Entities.Models;
using Repository.DTO.Common;
using Repository.Mapping;

namespace Repository.DTO
{
    public class SeasonsDto : CardItemDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Season, SeasonsDto>()
                .ForMember(to => to.Name, from => from.MapFrom(x => x.Year))
                .ForMember(to => to.ImageLink, from => from.MapFrom(x => x.Image.Link));
        }
    }
}
