using System;

namespace Entities.DataTransferObjects
{
    public record TyreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ImageDto ImageDto { get; set; }
        public ManufacturerDto ManufacturerDto { get; set; }
    }
}
