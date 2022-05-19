namespace Services.DTOCRUD
{
    public record EngineCreateDto
    {
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
    }
}
