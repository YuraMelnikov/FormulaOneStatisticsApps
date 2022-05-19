namespace Services.DTOCRUD
{
    public record ChassisCreateDto
    {
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
    }
}
