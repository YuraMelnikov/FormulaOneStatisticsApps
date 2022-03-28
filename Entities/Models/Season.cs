using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Season")]
    public class Season : Entity
    {
        public int Year { get; set; }
        public Guid IdImage { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
