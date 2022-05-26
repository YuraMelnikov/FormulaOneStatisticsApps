using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TypeStartField")]
    public class TypeStartField : Entity
    {
        [Required]
        public int FirstLine { get; set; }

        [Required]
        public int SecondLine { get; set; }
    }
}
