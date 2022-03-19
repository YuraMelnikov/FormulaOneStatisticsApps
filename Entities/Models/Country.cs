using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Country")]
    public class Country : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "NameRu is required")]
        public string NameRu { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }

    }
}
