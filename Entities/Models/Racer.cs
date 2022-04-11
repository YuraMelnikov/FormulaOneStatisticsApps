using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.Models
{
    [Table("Racer")]
    public class Racer : Entity
    {
        [Required(ErrorMessage = "Country is required")]
        public Guid IdCountry { get; set; }
        [Required(ErrorMessage = "Born date is required")]
        public DateTime Born { get; set; }
        [Required(ErrorMessage = "Born in is required")]
        public string BornIn { get; set; }
        public DateTime? Dead { get; set; }
        [Required(ErrorMessage = "Dead in is required")]
        public string DeadIn { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Second name is required")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string FirstNameRus { get; set; }
        [Required(ErrorMessage = "Second name is required")]
        public string SecondNameRus { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public Guid IdImage { get; set; }
        [Required(ErrorMessage = "Text data is required")]
        public string TextData { get; set; }

        [ForeignKey("IdCountry")]
        public Country Country { get; set; }
        [ForeignKey("IdImage")]
        public Image Image { get; set; }

        public string TimeApiId { get; set; }
        public bool? IsUpdate { get; set; }

        [NotMapped]
        public string RacerNameEng 
        { 
            get 
            { 
                return FirstName + " " + SecondName;
            }
        }
    }
}
