using System;

namespace Entities.DataTransferObjects
{
    public  class CountryDto
    {
        public Guid Id;
        public string Name { get; set; }
        public ImageDto Image { get; set; }
    }
}
