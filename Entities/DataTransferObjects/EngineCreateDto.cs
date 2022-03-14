using System;

namespace Entities.DataTransferObjects
{
    public class EngineCreateDto
    {
        public Guid IdManufacturer { get; set; }
        public Guid IdImage { get; set; }
        public string Name { get; set; }
    }
}
