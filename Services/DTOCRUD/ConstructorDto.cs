using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record ConstructorDto : EntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdCountry { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public string Logo { get; set; }
    }
}
