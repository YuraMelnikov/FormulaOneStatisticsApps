using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Track")]
    public class Track : Entity
    {
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NameRus is required")]
        public string NameRus { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Guid IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public  Country Country { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
