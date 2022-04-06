using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Team")]
    public class Team : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
