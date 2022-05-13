namespace Services.DTOCRUD
{
    public record GrandPrixResultDto
    {
        public Guid Id {get;set;}
        public string Note { get; set; }
        public string NoteRus { get; set; }
        public string Classification { get; set; }
        public string ClassificationRus { get; set; }
    }
}
