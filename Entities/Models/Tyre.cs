using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Tyre")]
    public class Tyre : Entity
    {
        [Required(ErrorMessage = "Manufacturer is required")]
        public Guid IdManufacturer { get; set; }
        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }
        [ForeignKey("IdManufacturer")]
        public  Manufacturer Manufacturer { get; set; }
    }
}
