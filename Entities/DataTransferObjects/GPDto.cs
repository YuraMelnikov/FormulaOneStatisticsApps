using System;

namespace Entities.DataTransferObjects
{
    public class GPDto
    { 
        public Guid Id { get; set; }
        public int Num { get; set; }
        public int NumInSeason { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Weather { get; set; }
        public float PercentDistance { get; set; }
        public TrackСonfigurationDto TrackСonfigurationDto { get; set; }
        public ImageDto ImageDto { get; set; }
    }
}
