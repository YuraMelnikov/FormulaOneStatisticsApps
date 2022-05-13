namespace Services.DTO
{
    public record GrandPrixFastLapDto
    {
        public string Racer { get; set; }
        public string Time { get; set; }
        public string AverageSpeed { get; set; }
    }
}
