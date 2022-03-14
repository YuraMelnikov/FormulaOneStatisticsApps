using System;

namespace Entities.DataTransferObjects
{
    public class TyreCreateDto
    {
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
    }
}
