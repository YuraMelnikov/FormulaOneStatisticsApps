namespace Services.DTO
{
    public record ConstructorSeasonDto
    {
        public Guid IdSeason { get; set; }
        public int Season { get; set; }
        public IEnumerable<RacerTeamsAndChassies> Chassis { get; set; }
        public IEnumerable<RacerTeamsAndChassies> Livery { get; set; }
        public float Points { get; set; }
        public int Position { get; set; }
        public int Win { get; set; }
        public int PolePosition { get; set; }
        public int FastLap { get; set; }
        public string TopStart { get; set; }
        public string TopFinish { get; set; }
    }
}
