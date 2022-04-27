namespace Services.DTO
{
    public record TrackGrandPrixDto
    {
        public Guid id { get; set; }
        public int Number { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Weather { get; set; }
        public Guid IdWinnerRacer { get; set; }
        public string RacerWinner { get; set; }
        public Guid IdWinnerTeam { get; set; }
        public string TeamWinner { get; set; }
    }
}