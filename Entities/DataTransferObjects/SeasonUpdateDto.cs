using System;

namespace Entities.DataTransferObjects
{
    public class SeasonUpdateDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public Guid IdImage { get; set; }
        public Guid IdTypeCalculate { get; set; }
    }
}
