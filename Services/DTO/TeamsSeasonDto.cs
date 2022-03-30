﻿using AutoMapper;
using Entities.Models;
using Services.DTO.Common;
using Services.Mapping;

namespace Services.DTO
{
    public class TeamsSeasonDto : IMapFrom
    {
        public Guid IdTeam { get; set; }
        public string Name { get; set; }
        public IEnumerable<LabelItemWhisId> Chassies { get; set; }
        public IEnumerable<LabelItemWhisId> Racers { get; set; }
        public IEnumerable<LabelItemWhisId> Engines { get; set; }
        public IEnumerable<LabelItemWhisId> Tyres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Participant, TeamsSeasonDto>()
                .ForMember(to => to.IdTeam, from => from.MapFrom(x => x.IdTeam))
                .ForMember(to => to.Name, from => from.MapFrom(x => x.Team.Name));
        }
    }
}
