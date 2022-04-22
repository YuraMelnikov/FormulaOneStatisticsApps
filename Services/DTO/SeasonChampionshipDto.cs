namespace Services.DTO
{
    public record SeasonChampionshipDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Points { get; set; }
        public int Position { get; set; }
        public IEnumerable<SeasonChampColumnDto> Result { get; set; }
    }
}