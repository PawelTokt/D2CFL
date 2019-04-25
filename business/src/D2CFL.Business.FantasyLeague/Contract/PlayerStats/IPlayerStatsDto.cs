using System;

namespace D2CFL.Business.FantasyLeague.Contract.PlayerStats
{
    public interface IPlayerStatsDto
    {
        Guid MatchId { get; set; }
        Guid PlayerId { get; set; }
        int Kill { get; set; }
        int Assist { get; set; }
        int Death { get; set; }
    }
}
