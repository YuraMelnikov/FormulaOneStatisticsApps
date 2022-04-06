using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TeamName")]
    public class TeamName : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IdCountry is required")]
        public Guid IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public Country Country { get; set; }

        public string TimeApiId { get; set; }
    }
}
