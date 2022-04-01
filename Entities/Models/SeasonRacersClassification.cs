using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("SeasonRacersClassification")]
    public class SeasonRacersClassification : Entity
    {
        [Required(ErrorMessage = "IdSeason is required")]
        public Guid IdSeason { get; set; }
        [ForeignKey("IdSeason")]
        public Season Season { get; set; }

        [Required(ErrorMessage = "IdRacer is required")]
        public Guid IdRacer { get; set; }
        [ForeignKey("IdRacer")]
        public Racer Racer { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public int Position { get; set; }

        [Required(ErrorMessage = "Points is required")]
        public float Points { get; set; }
    }
}
