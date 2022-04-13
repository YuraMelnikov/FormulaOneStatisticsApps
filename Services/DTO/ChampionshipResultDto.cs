namespace Services.DTO
{
    public record ChampionshipResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Points { get; set; }
        public string Position { get; set; }
        public IList<SeasonChampColumnDto> Result { get; set; }
    }
}
