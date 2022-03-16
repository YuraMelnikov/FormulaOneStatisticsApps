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

            CreateMap<Manufacturer, ManufacturerDto>()
                .ForMember(to => to.ImageLink,
                    from => from.MapFrom(x => x.Image.Link)); ;
            CreateMap<ManufacturerCreateDto, Manufacturer>();
            CreateMap<ManufacturerUpdateDto, Manufacturer>();

            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantCreateDto, Participant>(); 
            CreateMap<ParticipantUpdateDto, Participant>();

            CreateMap<Qualification, QualificationDto>();
            CreateMap<QualificationCreateDto, Qualification>();
            CreateMap<QualificationUpdateDto, Qualification>();

            CreateMap<Racer, RacerDto>()
                .ForMember(to => to.ImageLink,
                    from => from.MapFrom(x => x.Image.Link));
            CreateMap<RacerCreateDto, Racer>();
            CreateMap<RacerUpdateDto, Racer>();

            CreateMap<Season, SeasonDto>()
                .ForMember(to => to.ImageLink, 
                    from => from.MapFrom(x => x.Image.Link));
            CreateMap<SeasonCreateDto, Season>();
            CreateMap<SeasonUpdateDto, Season>();

            CreateMap<Team, TeamDto>();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>();

            CreateMap<TeamName, TeamNameDto>();
            CreateMap<TeamNameCreateDto, TeamName>();
            CreateMap<TeamNameUpdateDto, TeamName>();

            CreateMap<Track, TrackDto>()
                .ForMember(to => to.ImageLink,
                    from => from.MapFrom(x => x.Image.Link)); ;
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
