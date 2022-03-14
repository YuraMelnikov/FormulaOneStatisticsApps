using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Chassis")]
    public class Chassis : EntityId
    {
        [Required(ErrorMessage = "Manufacturer is required")]
        public Guid IdManufacturer { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Livery is required")]
        public Guid IdLivery { get; set; }

        [ForeignKey("IdManufacturer")]
        public Manufacturer Manufacturer { get; set; }
        [ForeignKey("IdImage")]
        public Image Image { get; set; }
        [ForeignKey("IdLivery")]
        public Image Livery { get; set; }
    }
}
