using System;

namespace Entities.DataTransferObjects
{
    public class TeamCreateDto
    {
        public Guid IdCountry { get; set; }
        public string ShortName { get; set; }
        public Guid IdImage { get; set; }
    }
}
