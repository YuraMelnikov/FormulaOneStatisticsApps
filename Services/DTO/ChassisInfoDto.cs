namespace Services.DTO
{
    public record ChassisInfoDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Livery { get; set; }
        public float Points { get; set; }
        public int Win { get; set; }
        public int PolePosition { get; set; }
        public int FastLap { get; set; }
        public int TopStart { get; set; }
        public string TopFinish { get; set; }
    }
}
