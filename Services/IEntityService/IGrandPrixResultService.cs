﻿using Services.DTO;

namespace Services.IEntityService
{
    public interface IGrandPrixResultService
    {
        Task<WinnerDto> GetWinner(Guid idGrandPrix);
        Task<GrandPrixResultRacerDto> GetRacerResult(Guid idParticipant);
    }
}
