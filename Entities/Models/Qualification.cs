using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Qualification")]
    public class Qualification : Entity
    {
        [Required(ErrorMessage = "Participant is required")]
        public Guid IdParticipant { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public int Position { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Points is required")]
        public float Points { get; set; }

        [ForeignKey("IdParticipant")]
        public  Participant Participant { get; set; }
    }
}
