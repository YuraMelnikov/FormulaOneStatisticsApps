namespace Services.DTO
{
    public record SeasonCalendarDto
    {
        public Guid IdGrandPrix { get;set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public Guid IdTrack { get; set; }
        public string TrackName { get; set; }
        public int Lap { get; set; }
        public decimal Distance { get; set; }
        public Guid IdWinnerRacer { get; set; }
        public string RacerWinner { get; set; }
        public Guid IdWinnerTeam { get; set; }
        public string TeamWinner { get; set; }
    }
}
