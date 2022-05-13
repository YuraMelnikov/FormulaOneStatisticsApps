namespace Services.DTO
{
    public record GrandPrixLeaderLapDto
    {
        public string Racer { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
    }
}
