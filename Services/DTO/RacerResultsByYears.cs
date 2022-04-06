namespace Services.DTO
{
    public record RacerResultsByYears
    {
        public Guid IdSeason { get; set; }
        public int Season { get; set; }
        public string Teams { get; set; }
        public string IdChassies { get; set; }
        public string Chassies { get; set; }
        public string LiveryLink { get; set; }
        public string Points { get; set; }
        public string Positions { get; set; }
        public string Win { get; set; }
        public string PolePosition { get; set; }
        public string FirstLap { get; set; }
        public string TopFinish { get; set; }
        public int GrandPrixes { get; set; }
    }
}
