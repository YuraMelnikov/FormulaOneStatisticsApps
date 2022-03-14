using System;

namespace Entities.DataTransferObjects
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public string Num { get; set; }

        public GPDto GPDto { get; set; }
        public TeamDto TeamDto { get; set; }
        public ChassiDto ChassiDto { get; set; }
        public EngineDto EngineDto { get; set; }
        public RacerDto RacerDto { get; set; }
        public TyreDto TyreDto { get; set; }
    }
}
