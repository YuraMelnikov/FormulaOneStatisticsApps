using AutoMapper;
using Entities.Models;
using Repository.DTO.Common;
using Repository.Mapping;

namespace Repository.DTO
{
    public class TracksDto : CardItemDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Track, TracksDto>()
                .ForMember(to => to.ImageLink, from => from.MapFrom(x => x.Image.Link));
        }
    }
}
