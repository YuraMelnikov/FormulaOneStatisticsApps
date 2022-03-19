using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Common
{
    public class EntityImg : Entity
    {
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
