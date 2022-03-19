using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Team")]
    public class Team : Entity
    {
        [Required(ErrorMessage = "Country is required")]
        public Guid IdCountry { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }

        [ForeignKey("IdCountry")]
        public Country Country { get; set; }
        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
