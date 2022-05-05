using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record GrandPrixDto : EntityDto
    {
        public Guid Id { get; set; }
        public Guid IdSeason { get; set; }
        public string? Season { get; set; }
        public Guid IdTrackСonfiguration { get; set; }
        public int Number { get; set; }
        public int NumberInSeason { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string? Image { get; set; }
        public string Weather { get; set; }
        public int NumberOfLap { get; set; }
        public string Text { get; set; }
        public Guid IdGrandPrixNames { get; set; }
        public string? GrandPrixNames { get; set; }
    }
}
