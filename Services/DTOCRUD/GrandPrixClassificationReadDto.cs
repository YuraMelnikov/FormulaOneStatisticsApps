using Services.DTO;

namespace Services.DTOCRUD
{
    public record GrandPrixClassificationReadDto : GrandPrixClassificationDto
    {
        public Guid IdEngine { get; set; }
        public string? Engine { get; set; }
        public Guid IdTyre { get; set; }
        public string? Tyre { get; set; }
        public string? ClassificationRus { get; set; }
        public string? NoteRus { get; set; }
    }
}
