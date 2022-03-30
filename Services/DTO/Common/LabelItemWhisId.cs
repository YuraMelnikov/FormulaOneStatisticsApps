using AutoMapper;
using Entities.Models;
using Services.Mapping;

namespace Services.DTO.Common
{
    public class LabelItemWhisId : IMapFrom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Racer, LabelItemWhisId>()
                .ForMember(to => to.Name, from => from.MapFrom(a => a.SecondName));
            profile.CreateMap<Tyre, LabelItemWhisId>();
            profile.CreateMap<Engine, LabelItemWhisId>();
            profile.CreateMap<Chassis, LabelItemWhisId>();
        }
    }
}
