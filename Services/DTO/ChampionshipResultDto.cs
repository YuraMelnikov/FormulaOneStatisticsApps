namespace Services.DTO
{
    public record ChampionshipResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string QualificationPosition { get; set; }
        public string RacePosition { get; set; }
        public decimal Point { get; set; }
    }
}
