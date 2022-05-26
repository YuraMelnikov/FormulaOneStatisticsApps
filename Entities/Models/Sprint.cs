using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Sprint")]
    public class Sprint : Entity
    {
        [Required]
        public Guid IdParticipant { get; set; }
        [ForeignKey("IdParticipant")]
        public Participant Participant { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string ClassificationRus { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public float Points { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string FastLap { get; set; }

        [Required]
        public string FastLapTime { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public string NoteRus { get; set; }
    }
}
