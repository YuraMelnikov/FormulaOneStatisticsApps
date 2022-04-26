namespace Services.DTO
{
    public record ConstructorChampionshipDto
    {
        public int Season { get; set; }
        public float Points { get; set; }
        public int Position { get; set; }
        public IEnumerable<ConstructorChampColumnDto> Result { get; set; }
    }
}
