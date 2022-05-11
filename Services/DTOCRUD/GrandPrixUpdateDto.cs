namespace Services.DTOCRUD
{
    public record GrandPrixUpdateDto
    {
        public Guid Id { get; set; }
        public string? Image { get; set; }
        public string? Text { get; set; }
    }
}
