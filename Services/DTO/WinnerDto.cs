using AutoMapper;
using Entities.Models;
using Services.DTO.Common;
using Services.Mapping;

namespace Services.DTO
{
    public record WinnerDto : EntityDto, IMapFrom
    {
        public Guid IdWinnerRacer { get; set; }
        public string RacerWinner { get; set; }
        public Guid IdWinnerTeam { get; set; }
        public string TeamWinner { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GrandPrixResult, WinnerDto>()
                .ForMember(to => to.IdWinnerRacer, from => from.MapFrom(x => x.Participant.IdRacer))
                .ForMember(to => to.RacerWinner, from => from.MapFrom(x => x.Participant.Racer.SecondName))
                .ForMember(to => to.IdWinnerTeam, from => from.MapFrom(x => x.Participant.IdTeam))
                .ForMember(to => to.TeamWinner, from => from.MapFrom(x => x.Participant.Team.Name));
        }
    }
}
