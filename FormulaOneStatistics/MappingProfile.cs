using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;

namespace FormulaOneStatistics
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<ImageForCreationDto, Image>();
            CreateMap<ImageForUpdateDto, Image>();

            CreateMap<Chassis, ChassiDto>();
            CreateMap<ChassiCreateDto, Chassis>();
            CreateMap<ChassiUpdateDto, Chassis>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryUpdateDto, Country>();

            CreateMap<Engine, EngineDto>();
            CreateMap<EngineCreateDto, Engine>();
            CreateMap<EngineUpdateDto, Engine>();

            CreateMap<FastLap, FastLapDto>();
            CreateMap<FastLapCreateDto, FastLap>();
            CreateMap<FastLapUpdateDto, FastLap>();

            CreateMap<GrandPrix, GPDto>();
            CreateMap<GPCreateDto, GrandPrix>();
            CreateMap<GPUpdateDto, GrandPrix>();

            CreateMap<GrandPrixResult, GPResultDto>();
            CreateMap<GPResultCreateDto, GrandPrixResult>();
            CreateMap<GPResultUpdateDto, GrandPrixResult>();

            CreateMap<LeaderLap, LeaderLapDto>();
            CreateMap<LeaderLapCreateDto, LeaderLap>();
            CreateMap<LeaderLapUpdateDto, LeaderLap>();

            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<ManufacturerCreateDto, Manufacturer>();
            CreateMap<ManufacturerUpdateDto, Manufacturer>();

            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantCreateDto, Participant>(); 
            CreateMap<ParticipantUpdateDto, Participant>();

            CreateMap<Qualification, QualificationDto>();
            CreateMap<QualificationCreateDto, Qualification>();
            CreateMap<QualificationUpdateDto, Qualification>();

            CreateMap<Racer, RacerDto>();
            CreateMap<RacerCreateDto, Racer>();
            CreateMap<RacerUpdateDto, Racer>();

            CreateMap<Season, SeasonDto>();
            CreateMap<SeasonCreateDto, Season>();
            CreateMap<SeasonUpdateDto, Season>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>();

            CreateMap<TeamName, TeamNameDto>();
            CreateMap<TeamNameCreateDto, TeamName>();
            CreateMap<TeamNameUpdateDto, TeamName>();

            CreateMap<Track, TrackDto>();
            CreateMap<TrackCreateDto, Track>();
            CreateMap<TrackUpdateDto, Track>();

            CreateMap<TrackСonfiguration, TrackСonfigurationDto>();
            CreateMap<TrackСonfigurationCreateDto, TrackСonfiguration>();
            CreateMap<TrackСonfigurationUpdateDto, TrackСonfiguration>();

            CreateMap<Tyre, TyreDto>();
            CreateMap<TyreCreateDto, Tyre>(); 
            CreateMap<TyreUpdateDto, Tyre>();
        }
    }
}
