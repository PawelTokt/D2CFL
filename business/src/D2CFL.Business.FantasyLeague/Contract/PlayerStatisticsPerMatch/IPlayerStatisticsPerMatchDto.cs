using System;

namespace D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch
{
    public interface IPlayerStatisticsPerMatchDto
    {
        Guid MatchId { get; set; }
        Guid PlayerId { get; set; }
        int Kills { get; set; }
        int Assists { get; set; }
        int Deaths { get; set; }
        double Points { get; set; }
    }
}