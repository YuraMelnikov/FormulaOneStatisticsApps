using System;

namespace Entities.DataTransferObjects
{
    public class EngineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ManufacturerDto ManufacturerDto { get; set; }
        public ImageDto ImageDto { get; set; }
    }
}
