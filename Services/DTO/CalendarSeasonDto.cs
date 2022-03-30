using AutoMapper;
using Entities.Models;
using Services.Mapping;

namespace Services.DTO
{
    public record CalendarSeasonDto : WinnerDto, IMapFrom
    {
        public Guid IdGrandPrix { get;set; }
        public string Date { get; set; }
        public Guid IdTrack { get; set; }
        public string TrackName { get; set; }
        public int Lap { get; set; }
        public decimal Distance { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WinnerDto, CalendarSeasonDto>();
        }
    }
}
