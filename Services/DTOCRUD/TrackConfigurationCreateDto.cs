namespace Services.DTOCRUD
{
    public record TrackConfigurationCreateDto
    {
        public Guid IdTrack { get; set; }
        public float Length { get; set; }
        public string Note { get; set; }
    }
}