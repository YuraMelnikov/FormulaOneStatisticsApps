﻿using System;

namespace Entities.DataTransferObjects
{
    public record ChassiCreateDto
    {
        public Guid IdManufacturer { get; set; }
        public string Name { get; set; }
        public Guid IdImage { get; set; }
        public Guid IdLivery { get; set; }
    }
}
