namespace Services.DTO
{
    public record GrandPrixLastResultDto
    {
        public int Position { get; set; }
        public string RacerFullName { get; set; }
        public string Constructor { get; set; }
        public string TimeGap { get; set; }
        public float Points { get; set; }
    }
}
