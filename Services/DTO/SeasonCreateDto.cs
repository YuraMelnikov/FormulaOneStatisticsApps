using AutoMapper;
using Entities.Models;
using Services.DTO.Common;
using Services.Mapping;

namespace Services.DTO
{
    public class SeasonCreateDto : EntityDto, IMapFrom
    {
        public int Year { get; set; }
        public Guid IdImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeasonCreateDto, Season>();
        }
    }
}
