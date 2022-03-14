using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ChassisImg")]
    public class ChassisImg : EntityImg
    {
        [Required(ErrorMessage = "Chassis is required")]
        public Guid IdChassi { get; set; }

        [ForeignKey("IdChassi")]
        public Chassis Chassi { get; set; }
    }
}
