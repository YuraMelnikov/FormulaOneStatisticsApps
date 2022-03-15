﻿using System;

namespace Entities.DataTransferObjects
{
    public record LeaderLapDto
    {
        public Guid Id { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
        public GPResultDto GPResultDto { get; set; }
    }
}
