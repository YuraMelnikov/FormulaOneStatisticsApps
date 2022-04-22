namespace Services.DTO
{
    public record RacerChampColumnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RacePosition { get; set; }
    }
}