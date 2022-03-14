using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ParticipantImg")]
    public class ParticipantImg : EntityImg
    {
        [Required(ErrorMessage = "Participant is required")]
        public Guid IdParticipant { get; set; }

        [ForeignKey("IdParticipant")]
        public Participant Participant { get; set; }
    }
}
