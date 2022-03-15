using System;

namespace Entities.DataTransferObjects
{
    public record TeamCreateDto
    {
        public Guid IdCountry { get; set; }
        public string ShortName { get; set; }
        public Guid IdImage { get; set; }
    }
}
