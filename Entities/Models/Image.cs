using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Image")]
    public class Image : Entity
    {
        [Required]
        public string Link { get; set; }
    }
}
