namespace Services.DTO
{
    public record RacerChampionshipDto
    {
        public int Season { get; set; }
        public float Points { get; set; }
        public int Position { get; set; }
        public IEnumerable<RacerChampColumnDto> Result { get; set; }
    }
}