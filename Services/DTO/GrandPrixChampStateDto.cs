namespace Services.DTO
{
    public record GrandPrixChampStateDto
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public float Points { get; set; }
    }
}
