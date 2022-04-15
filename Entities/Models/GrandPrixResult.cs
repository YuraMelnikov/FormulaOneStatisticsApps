using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("GrandPrixResult")]
    public class GrandPrixResult : Entity
    {
        [Required(ErrorMessage = "Participant is required")]
        public Guid IdParticipant { get; set; }

        [Required(ErrorMessage = "Classification is required")]
        public string Classification { get; set; }

        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Average speed is required")]
        public string AverageSpeed { get; set; }

        public int? Lap { get; set; }
        [Required(ErrorMessage = "Points is required")]
        public float Points { get; set; }

        public int? Position { get; set; }
        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }

        [ForeignKey("IdParticipant")]
        public  Participant Participant { get; set; }

        [Required(ErrorMessage = "NoteRus is required")]
        public string NoteRus { get; set; }

        [Required(ErrorMessage = "ClassificationRus is required")]
        public string ClassificationRus { get; set; }
    }
}
