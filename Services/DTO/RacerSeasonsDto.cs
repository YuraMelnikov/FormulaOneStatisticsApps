namespace Services.DTO
{
    public record RacerSeasonsDto
    {
        public Guid IdSeason { get; set; }
        public int Season { get; set; }
        public IList<RacerTeamsAndChassies> Chassies { get; set; }
        public string Points { get; set; }
        public string Positions { get; set; }
        public int Win { get; set; }
        public int PolePosition { get; set; }
        public int FastLap { get; set; }
        public string TopFinish { get; set; }
        public int GrandPrixes { get; set; }
    }
}
