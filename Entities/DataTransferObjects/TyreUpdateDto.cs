using System;

namespace Entities.DataTransferObjects
{
    public record TyreUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
    }
}
