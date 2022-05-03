namespace Services.DTOCRUD
{
    public record ImageWhisCountDto : ImageDto
    {
        public int ManufacturersCount { get; set; }
        public int ChassisCount { get; set; }
        public int LiveryCount { get; set; }
        public int ChassisImgsCount { get; set; }
        public int CountriesCount { get; set; }
        public int EnginesCount { get; set; }
        public int GrandPrixesCount { get; set; }
        public int GrandPrixImgsCount { get; set; }
        public int ParticipantImgCount { get; set; }
        public int RacerImgsCount { get; set; }
        public int RacersCount { get; set; }
        public int SeasonImgCount { get; set; }
        public int SeasonsCount { get; set; }
        public int TeamNamesCount { get; set; }
        public int TracksCount { get; set; }
        public int TrackСonfigurationsCount { get; set; }
        public int TyresCount { get; set; }
    }
}
