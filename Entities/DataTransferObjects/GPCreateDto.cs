using System;

namespace Entities.DataTransferObjects
{
    public class GPCreateDto
    {
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
