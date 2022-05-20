namespace Services.DTOCRUD
{
    public record TrackCreateDto
    {
        public Guid IdCountry { get; set; }
        public string Name { get; set; }
        public string NameRus { get; set; }
        public string Location { get; set; }
    }
}
