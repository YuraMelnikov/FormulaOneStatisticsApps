namespace Services.DTOCRUD
{
    public record ManufacturerDto
    {
        public Guid Id { get; set; }
        public Guid IdCountry { get; set; }
        public string Name { get; set; }
    }
}
