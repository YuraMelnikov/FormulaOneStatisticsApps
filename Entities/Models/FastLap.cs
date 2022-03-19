using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("FastLap")]
    public class FastLap : Entity
    {
        [Required(ErrorMessage = "Participant prix is required")]
        public Guid IdParticipant { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Average speed is required")]
        public string AverageSpeed { get; set; }

        [ForeignKey("IdParticipant")]
        public Participant Participant { get; set; }
    }
}
