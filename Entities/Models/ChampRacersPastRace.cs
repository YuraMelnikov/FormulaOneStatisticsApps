using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ChampRacersPastRace")]
    public class ChampRacersPastRace : Entity
    {
        [Required(ErrorMessage = "IdGrandPrix is required")]
        public Guid IdGrandPrix { get; set; }
        [ForeignKey("IdGrandPrix")]
        public GrandPrix GrandPrix { get; set; }

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
