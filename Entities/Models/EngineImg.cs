using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("EngineImg")]
    public class EngineImg : EntityImg
    {
        [Required(ErrorMessage = "Engine is required")]
        public Guid IdEngine { get; set; }
        
        [ForeignKey("IdEngine")]
        public Engine Engine { get; set; }
    }
}
