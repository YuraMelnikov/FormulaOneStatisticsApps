﻿using Services.DTO.Common;

namespace Services.DTOCRUD
{
    public record ImageCreateDto : EntityDto
    {
        public IEnumerable<Guid> Participant { get; set; }

        public Guid GrandPrix { get; set; }

        //public string Image { get; set; }
    }
}
