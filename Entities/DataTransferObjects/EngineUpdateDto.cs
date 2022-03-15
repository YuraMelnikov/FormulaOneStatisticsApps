using System;

namespace Entities.DataTransferObjects
{
    public record EngineUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdManufacturer { get; set; }
        public Guid IdImage { get; set; }
        public string Name { get; set; }
    }
}
