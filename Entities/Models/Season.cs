﻿using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Season")]
    public class Season : Entity
    {
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }
    }
}
