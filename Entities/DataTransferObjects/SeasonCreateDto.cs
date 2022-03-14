using System;

namespace Entities.DataTransferObjects
{
    public class SeasonCreateDto
    {
        public int Year { get; set; }
        public Guid IdImage { get; set; }
        public Guid IdTypeCalculate { get; set; }
    }
}
