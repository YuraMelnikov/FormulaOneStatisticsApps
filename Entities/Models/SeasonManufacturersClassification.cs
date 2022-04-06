using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("SeasonManufacturersClassification")]
    public class SeasonManufacturersClassification : Entity
    {
        [Required(ErrorMessage = "IdSeason is required")]
        public Guid IdSeason { get; set; }
        [ForeignKey("IdSeason")]
        public Season Season { get; set; }

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
