using Microsoft.AspNetCore.Http;
using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record ImageCreateDto : EntityDto
    {
       public List<string> Participant { get; set; }

        public Guid GrandPrix { get; set; }

        //public IFormFile Image { get; set; }
    }
}
