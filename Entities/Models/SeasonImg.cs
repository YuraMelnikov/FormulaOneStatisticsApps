using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("SeasonImg")]
    public class SeasonImg : EntityImg
    {
        [Required(ErrorMessage = "Season is required")]
        public Guid IdSeason { get; set; }

        [ForeignKey("IdSeason")]
        public Season Season { get; set; }
    }
}
