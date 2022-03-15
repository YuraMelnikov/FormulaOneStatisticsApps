using System;

namespace Entities.DataTransferObjects
{
    public record GPUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdTrackСonfiguration { get; set; }
        public int Num { get; set; }
        public int NumInSeason { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
        public string Weather { get; set; }
        public float PercentDistance { get; set; }
    }
}
