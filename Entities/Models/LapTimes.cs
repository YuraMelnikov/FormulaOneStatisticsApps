using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("LapTimes")]
    public class LapTimes : Entity
    {
        [Required]
        public Guid IdParticipant { get; set; }
        [ForeignKey("IdParticipant")]
        public Participant Participant { get; set; }

        [Required]
        public int Lap { get; set; }

        [Required]
        public int Posotion { get; set; }

        [Required]
        public string Time { get; set; }
    }
}
