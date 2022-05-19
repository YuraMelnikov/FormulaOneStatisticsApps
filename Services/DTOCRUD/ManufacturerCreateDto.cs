namespace Services.DTOCRUD
{
    public record ManufacturerCreateDto
    {
        public Guid IdCountry { get; set; }
        public string Name { get; set; }
    }
}
