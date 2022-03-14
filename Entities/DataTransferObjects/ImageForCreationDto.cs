using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class ImageForCreationDto
    {
        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
