using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("RacerImg")]
    public class RacerImg : EntityImg
    {
        [Required(ErrorMessage = "IdRacer")]
        public Guid IdRacer { get; set; }

        [ForeignKey("IdRacer")]
        public Racer Racer { get; set; }
    }
}
