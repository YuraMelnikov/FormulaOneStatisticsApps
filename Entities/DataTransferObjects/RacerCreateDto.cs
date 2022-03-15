using System;

namespace Entities.DataTransferObjects
{
    public record RacerCreateDto
    {
        public Guid IdCountry { get; set; }
        public DateTime Born { get; set; }
        public string BornIn { get; set; }
        public DateTime? Dead { get; set; }
        public string DeadIn { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Guid IdImage { get; set; }
        public string TextData { get; set; }
    }
}
