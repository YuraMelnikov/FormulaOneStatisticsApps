using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Image")]
    public class Image : EntityId
    {
        [Required]
        public string Link { get; set; }
    }
}
