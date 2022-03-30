using AutoMapper;
using Entities.Models;
using Services.DTO.Common;
using Services.Mapping;

namespace Services.DTO
{
    public record ManufacturersDto : CardItemDto, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Manufacturer, ManufacturersDto>()
                .ForMember(to => to.ImageLink, from => from.MapFrom(x => x.Image.Link));
        }
    }
}