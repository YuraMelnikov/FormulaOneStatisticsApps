namespace Services.DTOCRUD
{
    public record TeamNameCreateDto
    {
        public Guid IdCountry { get; set; }
        public string Name { get; set; }
        public string TimeApiId { get; set; }
    }
}
