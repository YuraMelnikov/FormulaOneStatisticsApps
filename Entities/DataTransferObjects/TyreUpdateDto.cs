using System;

namespace Entities.DataTransferObjects
{
    public class TyreUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
    }
}
