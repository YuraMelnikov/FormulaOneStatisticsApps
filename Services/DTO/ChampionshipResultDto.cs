namespace Services.DTO
{
    public record ChampionshipResultDto
    {
        public Guid Id { get; set; }
        public Guid IdParticipant { get; set; }
        public string Name { get; set; }
        public string RacePosition { get; set; }
        public float Point { get; set; }
        public int NumGrandPrix { get; set; }
        public string GrandPrixName { get; set; }
    }
}
