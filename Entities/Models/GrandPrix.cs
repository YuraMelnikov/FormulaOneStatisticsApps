using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.Models
{
    [Table("GrandPrix")]
    public class GrandPrix : Entity
    {
        [Required(ErrorMessage = "Season is required")]
        public Guid IdSeason { get; set; }
        [Required(ErrorMessage = "Track configuration is required")]
        public Guid IdTrackСonfiguration { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Number in season is required")]
        public int NumberInSeason { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Weather is required")]
        public string Weather { get; set; }

        [Required(ErrorMessage = "WeatherRus is required")]
        public string WeatherRus { get; set; }

        [Required(ErrorMessage = "Number of lan is required")]
        public int NumberOfLap { get; set; }

        [ForeignKey("IdSeason")]
        public Season Season { get; set; }
        [ForeignKey("IdTrackСonfiguration")]
        public TrackСonfiguration TrackСonfiguration { get; set; }
        [ForeignKey("IdImage")]
        public  Image Image { get; set; }

        [Required(ErrorMessage = "Text of lan is required")]
        public string Text { get; set; }

        [Required(ErrorMessage = "GrandPrixName is required")]
        public Guid IdGrandPrixNames { get; set; }
        [ForeignKey("IdGrandPrixNames")]
        public GrandPrixNames GrandPrixName { get; set; }
    }
}
