namespace Entities.Models
{
    public class mytable
    {
        public int resultId { get; set; }
        public int raceId { get; set; }
        public int raceYear { get; set; }
        public int raceRound { get; set; }
        public int driverId { get; set; }
        public string driver { get; set; }
        public int constructorId { get; set; }
        public string constructor { get; set; }
        public string number { get; set; }
        public int grid { get; set; }
        public string position { get; set; }
        public string positionText { get; set; }
        public int positionOrder { get; set; }
        public string points { get; set; }
        public int laps { get;set;}
        public string time { get; set; }
        public string milliseconds { get; set; }
        public string fastestLap { get; set; }
        public string rank { get; set; }
        public string fastestLapTime { get; set; }
        public string fastestLapSpeed { get; set; }
    }
}
