using AutoMapper;
using Entities.Models;
using Services.DTO.Common;
using Services.Mapping;

namespace Services.DTO
{
    public class CalendarSeasonDto : EntityDto, IMapFrom
    {
        public Guid IdGrandPrix { get;set; }
        public DateTime Date { get; set; }
        public Guid IdTrack { get; set; }
        public string TrackName { get; set; }
        public int Lap { get; set; }
        public decimal Distance { get; set; }
        public Guid IdWinnerRacer { get; set; }
        public string RacerWinner { get; set; }
        public Guid IdWinnerTeam { get;set; }
        public string TeamWinner { get;set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GrandPrix, CalendarSeasonDto>()
                .ForMember(to => to.IdGrandPrix, from => from.MapFrom(x => x.Id))
                .ForMember(to => to.IdTrack, from => from.MapFrom(x => x.TrackСonfiguration.Track.Id))
                .ForMember(to => to.TrackName, from => from.MapFrom(x => x.TrackСonfiguration.Track.Name))
                .ForMember(to => to.Lap, from => from.MapFrom(x => x.NumberOfLap))
                .ForMember(to => to.Distance, from => from.MapFrom(x => x.TrackСonfiguration.Length * x.NumberOfLap));

            profile.CreateMap<WinnerDto, CalendarSeasonDto>();
        }
    }
}
