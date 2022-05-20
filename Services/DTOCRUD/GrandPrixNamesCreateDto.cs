namespace Services.DTOCRUD
{
    public record GrandPrixNamesCreateDto
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
