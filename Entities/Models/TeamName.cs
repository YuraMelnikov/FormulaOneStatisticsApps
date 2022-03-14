using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TeamName")]
    public class TeamName : EntityId
    {
        [Required(ErrorMessage = "Team is required")]
        public Guid IdTeam { get; set; }
        [Required(ErrorMessage = "Season is required")]
        public Guid IdSeason { get; set; }
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [ForeignKey("IdTeam")]
        public Team Team { get; set; }
        [ForeignKey("IdSeason")]
        public Season Season { get; set; }
    }
}
