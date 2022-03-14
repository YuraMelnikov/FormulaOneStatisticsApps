using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("GrandPrixImg")]
    public class GrandPrixImg : EntityImg
    {
        [Required(ErrorMessage = "Grand prix is required")]
        public Guid IdGrandPrix { get; set; }

        [ForeignKey("IdGrandPrix")]
        public GrandPrix GrandPrix { get; set; }
    }
}
