using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Engine")]
    public class Engine : EntityId
    {
        [Required(ErrorMessage = "Manufacturing is required")]
        public Guid IdManufacturer { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [ForeignKey("IdManufacturer")]
        public  Manufacturer Manufacturer { get; set; }
        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
