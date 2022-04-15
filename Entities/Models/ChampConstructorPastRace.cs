using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ChampConstructorPastRace")]
    public class ChampConstructorPastRace : Entity
    {
        [Required(ErrorMessage = "IdGrandPrix is required")]
        public Guid IdGrandPrix { get; set; }
        [ForeignKey("IdGrandPrix")]
        public GrandPrix GrandPrix { get; set; }

        [Required(ErrorMessage = "IdTeamName is required")]
        public Guid IdTeamName { get; set; }
        [ForeignKey("IdTeamName")]
        public TeamName TeamName { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public int Position { get; set; }

        [Required(ErrorMessage = "Points is required")]
        public float Points { get; set; }
    }
}
