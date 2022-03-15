using System;

namespace Entities.DataTransferObjects
{
    public record TyreCreateDto
    {
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
    }
}
