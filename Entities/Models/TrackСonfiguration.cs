using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("TrackСonfiguration")]
    public class TrackСonfiguration : Entity
    {
        [Required(ErrorMessage = "Track is required")]
        public Guid IdTrack { get; set; }
        [Required(ErrorMessage = "Image configuration is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Length is required")]
        public float Length { get; set; }
        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }

        [ForeignKey("IdImage")]
        public Image Image { get; set; }
        [ForeignKey("IdTrack")]
        public Track Track { get; set; }
    }
}