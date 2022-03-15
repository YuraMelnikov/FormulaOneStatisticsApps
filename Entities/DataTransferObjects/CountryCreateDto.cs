using System;

namespace Entities.DataTransferObjects
{
    public record CountryCreateDto
    {
        public string Name { get; set; }
        public Guid IdImage { get; set; }
    }
}
