using AutoMapper;
using Entities.Models;
using Repository.DTO.Common;
using Repository.Mapping;

namespace Repository.DTO
{
    public class ManufacturersDto : CardItemDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Manufacturer, ManufacturersDto>()
                .ForMember(to => to.ImageLink, from => from.MapFrom(x => x.Image.Link));
        }
    }
}