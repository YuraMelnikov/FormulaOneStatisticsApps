using System;

namespace Entities.DataTransferObjects
{
    public class ManufacturerUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdCountry { get; set; }
        public Guid IdImage { get; set; }
        public string Name { get; set; }
    }
}
