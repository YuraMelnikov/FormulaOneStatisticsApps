using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("GrandprixNote")]
    public class GrandprixNote : Entity
    {
        [Required(ErrorMessage = "Grand prix is required")]
        public Guid IdGrandPrix { get; set; }
        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }

        [ForeignKey("IdGrandPrix")]
        public GrandPrix GrandPrix { get; set; }
    }
}
